using Domain.Entities;

namespace ServiceLayer.Interfaces
{
	public interface IServiceService
	{
		Task<string> CreateService(Service service);
		Task<List<Service>> GetService();
		Task<Service> GetServiceByID(int id);
		Task<string> DeleteService(int id);
		Task<string> UpdateService(int id, Service service);
	}
}
