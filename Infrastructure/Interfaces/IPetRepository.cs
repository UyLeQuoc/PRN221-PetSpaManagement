using Domain.Entities;
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
    }
}