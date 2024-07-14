using Domain.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class WeightRepository : IWeightRepositorycs
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
            var weightList = await _genericRepository.GetAllAsync(w => w.IsDeleted == false);
            if (weightList != null)
                return weightList;
            else
                throw new Exception("No Weights Found");
        }
    }
}
