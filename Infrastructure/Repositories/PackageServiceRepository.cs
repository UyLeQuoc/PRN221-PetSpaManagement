using Domain.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class PackageServiceRepository : IPackageServiceRepository
    {
        private readonly IGenericRepository<PackageService> _genericRepository;

        public PackageServiceRepository(IGenericRepository<PackageService> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task AddPackageService(int spaPackageId, int serviceId)
        {
            try
            {
                var packageService = new PackageService
                {
                    SpaPackageId = spaPackageId,
                    ServiceId = serviceId
                };

                await _genericRepository.AddAsync(packageService);
                await _genericRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding package service: " + ex.Message);
            }
        }
    }
}
