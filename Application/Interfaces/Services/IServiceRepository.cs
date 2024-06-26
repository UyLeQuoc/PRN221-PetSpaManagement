using Application.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IServiceRepository
    {
        Task<string> CreateService(Service service);
        Task<List<Service>> GetService();
        Task<Service> GetServiceByID(int id);
        Task<string> DeleteService(int id);
        Task<string> UpdateService(int id, Service service);
    }
}