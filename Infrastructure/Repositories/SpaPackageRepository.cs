using Domain.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class SpaPackageRepository : ISpaPackageRepository
    {
        private readonly IGenericRepository<SpaPackage> _genericRepositorySpaPackage;
        private readonly IGenericRepository<PackageService> _genericRepositoryPackageService;

        public SpaPackageRepository(IGenericRepository<SpaPackage> genericRepositorySpaPackage, IGenericRepository<PackageService> genericRepositoryPackageService)
        {
            _genericRepositorySpaPackage = genericRepositorySpaPackage;
            _genericRepositoryPackageService = genericRepositoryPackageService;
        }

        public async Task<string> CreateSpaPackage(SpaPackage spaPackage, List<int> serviceIds)
        {
            try
            {
                if (spaPackage == null)
                 throw new Exception ("Package Infomation is null");

                if (!serviceIds.Any())
                    throw new Exception("No Service selected");

                await _genericRepositorySpaPackage.AddAsync(spaPackage);
                await _genericRepositorySpaPackage.SaveChangesAsync();

                foreach (var serviceId in serviceIds)
                {
                    var packageService = new PackageService
                    {
                        SpaPackageId = spaPackage.Id,
                        ServiceId = serviceId
                    };
                    await _genericRepositoryPackageService.AddAsync(packageService);
                }

                if (await _genericRepositoryPackageService.SaveChangesAsync() > 0)
                    return "Create Successfully";
                else
                    throw new Exception("Create Failed");
            }
            catch (Exception ex)
            {
                throw new Exception("Create Failed: " + ex.Message);
            }

        }

        public async Task<List<SpaPackage>> GetSpaPackages()
        {
            return await _genericRepositorySpaPackage.GetAllAsync(x => x.IsDeleted == false);
        }

    }
}
