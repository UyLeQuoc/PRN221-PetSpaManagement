using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Commons;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        private readonly PetSpaManagementDbContext _context;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public PetRepository(PetSpaManagementDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _context = context;
            _timeService = timeService;
            _claimsService = claimsService;
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            return await _context.Pets.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Pet> UpdatePetAsync(Pet updatedPet)
        {
            var existingPet = await _context.Pets.FindAsync(updatedPet.Id);
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
            existingPet.UserId = updatedPet.UserId ?? existingPet.UserId;
            existingPet.ModifiedAt = _timeService.GetCurrentTime();

            await _context.SaveChangesAsync();
            return existingPet;
        }

        public async Task<bool> DeletePetAsyncByIdChecking(Pet deletePet, int userId)
        {
            var checkAppointment = await _context.Appointments.AnyAsync(x => x.PetId == deletePet.Id && x.Status != "CANCELLED");
            if (checkAppointment)
            {
                throw new Exception("Please cancel or complete the appointment before deleting your pet");
            }

            deletePet.IsDeleted = true;
            deletePet.DeletedBy = userId;
            _context.Update(deletePet);

            return true;
        }

        public async Task<Pagination<Pet>> GetAllPetsFilterAsync(string search, PaginationParameter pagination)
        {
            var query = _context.Pets.Include(x => x.User).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search) || p.Id.ToString().Contains(search));
            }
            var list = await query.OrderBy(x => x.CreatedAt).ToListAsync();
            int count = list.Count();
            list = list.Skip((pagination.PageIndex - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();
            var result = new Pagination<Pet>(list)
            {
                CurrentPage = pagination.PageIndex,
                PageSize = pagination.PageSize,
                TotalCount = count,
                PageIndex = pagination.PageIndex,
            };

            return result;
        }
    }
}