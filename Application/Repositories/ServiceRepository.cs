﻿using Application.Interfaces.IServices;
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
            var checkService = await _genericRepository.AnyAsync(x => x.Name.ToLower().Trim().Equals(service.Name.ToLower().Trim()) && x.IsDeleted == false);
            if (checkService)
                throw new Exception("Service already exists");

            await _genericRepository.AddAsync(service);
            if (await _genericRepository.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                throw new Exception("Create Failed");
        }

        public async Task<List<Service>> GetService()
        {
            var serviceList = await _genericRepository.GetAllAsync(s => s.IsDeleted == false);
            if (serviceList != null)
                return serviceList;
            else
                throw new Exception("No Service Found");
        }

        public async Task<Service> GetServiceByID(int id)
        {
            var service = await _genericRepository.GetByIdAsync(id);
            if (service != null)
                return service;
            else
                throw new Exception("No Service Found");
        }

        public async Task<string> DeleteService(int id)
        {
            var service = await _genericRepository.GetByIdAsync(id);
            if (service == null)
                return "Service not found";

            _genericRepository.SoftRemove(service);
            if (await _genericRepository.SaveChangesAsync() > 0)
                return "Delete Successfully";
            else
                return "Delete Failed";
        }

        public async Task<string> UpdateService(int id, Service service)
        {
            var serVice = await _genericRepository.GetByIdAsync(id);
            if (serVice == null)
                return "Service not found";

            serVice.Name = service.Name;
            serVice.Description = service.Description;
            serVice.Duration = service.Duration;

            _genericRepository.Update(serVice);
            if (await _genericRepository.SaveChangesAsync() > 0)
                return "Update Successfully";
            else
                return "Update Failed";
        }
    }
}
