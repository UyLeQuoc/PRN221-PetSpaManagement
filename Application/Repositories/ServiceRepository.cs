using Application.Interfaces.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ServiceRepository 
    {
        private readonly IServiceRepository _serviceRepository;
        public async Task<string> AddAsync(Service service)
        {   
            //service.CreatedBy = ID;
            service.CreationDate = DateTime.Now;
            _serviceRepository.AddAsync(service);
            if( await _serviceRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                return "Create Failed";
        }
    }
}
