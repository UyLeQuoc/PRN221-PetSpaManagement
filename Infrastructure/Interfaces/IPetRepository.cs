using Domain.Entities;
using RepositoryLayer.Commons;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        Task<bool> DeletePetAsyncByIdChecking(Pet deletePet, int userId);

        Task<Pagination<Pet>> GetAllPetsFilterAsync(string search, PaginationParameter pagination);
    }
}