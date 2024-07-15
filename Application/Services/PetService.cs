using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Commons;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class PetService : IPetService
    {
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;

        public PetService(IMapper mapper, IClaimsService claimsService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Pet>> GetAllPets()
        {
            return await _unitOfWork.PetRepository.GetAllAsync(x => x.IsDeleted == false, x => x.User);
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _unitOfWork.PetRepository.GetByIdAsync(id, null, x => x.User);
        }

        public async Task<Pet> CreatePetAsync(Pet pet)
        {
            try
            {
                var userid = _claimsService.GetCurrentUserId == -1 ? 1 : _claimsService.GetCurrentUserId;

                var newPet = new Pet()
                {
                    Name = pet.Name,
                    Age = pet.Age,
                    Description = pet.Description,
                    PictureUrl = pet.PictureUrl,
                    Type = pet.Type,
                    UserId = pet.UserId
                };

                var result = await _unitOfWork.PetRepository.AddAsync(newPet);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    return newPet;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Pet> UpdatePetAsync(Pet updatedPet)
        {
            try
            {
                var existingPet = await _unitOfWork.PetRepository.GetByIdAsync(updatedPet.Id);
                if (existingPet == null)
                {
                    throw new ArgumentException("Pet not found.");
                }

                // Update properties using ?? to keep existing values if new values are null
                existingPet.Name = updatedPet.Name ?? existingPet.Name;
                existingPet.Age = updatedPet.Age ?? existingPet.Age;
                existingPet.Description = updatedPet.Description ?? existingPet.Description;
                existingPet.PictureUrl = updatedPet.PictureUrl ?? existingPet.PictureUrl;
                existingPet.Type = updatedPet.Type ?? existingPet.Type;

                _unitOfWork.PetRepository.Update(existingPet);

                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    return existingPet;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeletePetAsync(int id)
        {
            try
            {
                var existingPet = await _unitOfWork.PetRepository.GetByIdAsync(id);
                if (existingPet == null)
                {
                    throw new ArgumentException("Pet not found.");
                }

                await _unitOfWork.PetRepository.SoftRemove(id);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<Pet>> GetAllPetsByUserId(int id)
        {
            return await _unitOfWork.PetRepository.GetAllAsync(x => x.IsDeleted == false && x.UserId == id, x => x.User);
        }

    }
}