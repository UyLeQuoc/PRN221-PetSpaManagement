using Domain.Entities;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class WeightService : IWeightService
    {

        private readonly IWeightRepository _weightRepository;

        public WeightService(IWeightRepository weightRepository)
        {
            _weightRepository = weightRepository;
        }

        public async Task<string> CreateWeight(Weight weight)
        {
            return await _weightRepository.CreateWeight(weight);
        }

        public async Task<string> DeleteWeight(int id)
        {
            return await _weightRepository.DeleteWeight(id); 
        }

        public async Task<Weight> GetWeightById(int id)
        {
            return await _weightRepository.GetWeightById(id);
        }

        public async Task<List<Weight>> GetWeights()
        {
            return await _weightRepository.GetWeights();
        }

        public async Task<string> UpdateWeight(int id, Weight weight)
        {
            return await _weightRepository.UpdateWeight(id, weight);
        }
    }
}
