using Domain.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
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
                    throw new Exception("Package Infomation is null");

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

        public async Task<SpaPackageDetailResponse> GetSpaPackageByID(int id)
        {
            var spaPackage = await _genericRepositorySpaPackage.GetByIdAsync(id, x => x.IsDeleted == false);
            if (spaPackage == null)
                throw new Exception("Package not found");

            var packageServices = await _genericRepositoryPackageService.GetAllAsync(x => x.SpaPackageId == id && x.IsDeleted == false, x => x.Service, x => x.Service.Weight );
            if (packageServices == null)
                throw new Exception("Package Services not found");

            SpaPackageDetailResponse response = new SpaPackageDetailResponse();
            response.SpaPackage = spaPackage;

            if (response.Services == null)
            {
                response.Services = new List<Service>();
            }

            foreach (var packageService in packageServices)
            {
                response.Services.Add(packageService.Service);
            }

            return response;
        }
    }
}
