using Domain.Entities;
using RepositoryLayer.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IPetService
    {
        Task<Pet> CreatePetAsync(Pet pet);
        Task<bool> DeletePetAsync(int id);
        Task<List<Pet>> GetAllPets();
        Task<Pet> GetPetById(int id);
        Task<Pet> UpdatePetAsync(Pet updatedPet);
        Task<List<Pet>> GetAllPetsByUserId(int id);
        Task<bool> DeletePetAsyncByIdChecking(int id, int userId);
        Task<Pagination<Pet>> GetAllPetsFilter(string search, PaginationParameter pagination);
    }
}