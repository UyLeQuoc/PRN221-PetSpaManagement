using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IWeightService
    {
        Task<string> CreateWeight(Weight weight);
        Task<List<Weight>> GetWeights();
        Task<Weight> GetWeightById(int id);
        Task<string> DeleteWeight(int id);
        Task<string> UpdateWeight(int id, Weight weight);
    }
}
