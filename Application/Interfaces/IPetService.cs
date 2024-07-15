using Domain.Entities;
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
    }
}