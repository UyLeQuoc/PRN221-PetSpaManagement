using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<string> CreateService(Service service)
        {
             return await _serviceRepository.CreateService(service);
        }

        public async Task<string> DeleteService(int id)
        {
            return await _serviceRepository.DeleteService(id);
        }

        public async Task<List<Service>> GetService()
        {
            return await _serviceRepository.GetService();
        }

        public async Task<Service> GetServiceByID(int id)
        {
            return await _serviceRepository.GetServiceByID(id);
        }

        public async Task<string> UpdateService(int id, Service service)
        {
            return await _serviceRepository.UpdateService(id, service);
        }
    }
}
