using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly IGenericRepository<Service> _genericRepository;

        public ServiceRepository(IGenericRepository<Service> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<string> CreateService(Service service)
        {   
            var newService = new Service()
            {
                Name = service.Name,
                Description = service.Description,
                Duration = service.Duration,
            };
            _genericRepository.AddAsync(newService);
            if( await _genericRepository.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                return "Create Failed";
        }
    }
}
