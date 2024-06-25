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
        private readonly IServiceService _serviceService;

        public ServiceService(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<string> AddAsync(Service service)
        {
             return await _serviceService.AddAsync(service);
        }

    }
}
