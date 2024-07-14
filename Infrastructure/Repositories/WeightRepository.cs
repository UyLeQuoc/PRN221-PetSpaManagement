using Domain.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class WeightRepository : IWeightRepository
    {
        private readonly IGenericRepository<Weight> _genericRepository;

        public WeightRepository(IGenericRepository<Weight> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<string> CreateWeight(Weight weight)
        {
            var checkWeight = await _genericRepository.AnyAsync(x => x.FromWeight == weight.FromWeight && x.ToWeight == weight.ToWeight && x.IsDeleted == false);
            if(checkWeight)
                throw new Exception("This Range of Weight already exists");

            await _genericRepository.AddAsync(weight);
            if (await _genericRepository.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                throw new Exception("Create Failed");
        }

        public async Task<List<Weight>> GetWeights()
        {
            var weightList = await _genericRepository.GetAllAsync(x => x.IsDeleted == false);
            if (weightList != null)
                return weightList;
            else
                throw new Exception("No Weights Found");
        }

        public async Task<Weight> GetWeightById(int id)
        {
            var weight = await _genericRepository.GetByIdAsync(id, x => x.IsDeleted == false);
            if (weight != null)
                return weight;
            else
                throw new Exception("Weight not found");
        }

        public async Task<string> DeleteWeight(int id)
        {
            var weight = await _genericRepository.GetByIdAsync(id, x => x.IsDeleted == false);
            if (weight == null)
                return "Weight not found";

            _genericRepository.SoftRemove(weight);
            if (await _genericRepository.SaveChangesAsync() > 0)
                return "Delete Successfully";
            else
                return "Delete Failed";
        }

        public async Task<string> UpdateWeight(int id, Weight weight)
        {
            var existingWeight = await _genericRepository.GetByIdAsync(id, x => x.IsDeleted == false);
            if (existingWeight == null)
                return "Weight not found";

            var checkWeight = await _genericRepository.AnyAsync(x => x.Id != id && x.FromWeight == weight.FromWeight && x.ToWeight == weight.ToWeight && x.IsDeleted == false);
            if (checkWeight)
                throw new Exception("This Range of Weight already exists");

            existingWeight.FromWeight = weight.FromWeight;
            existingWeight.ToWeight = weight.ToWeight;

            _genericRepository.Update(existingWeight);
            if (await _genericRepository.SaveChangesAsync() > 0)
                return "Update Successfully";
            else
                return "Update Failed";
        }
    }
}
