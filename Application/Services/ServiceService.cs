using Domain.Entities;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
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
