using Domain.Entities;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IWeightRepository
    {
        Task<string> CreateWeight(Weight weight);
        Task<List<Weight>> GetWeights();
        Task<Weight> GetWeightById(int id);
        Task<string> DeleteWeight(int id);
        Task<string> UpdateWeight(int id, Weight weight);
    }
}
