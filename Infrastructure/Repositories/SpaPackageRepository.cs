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
            return await _genericRepositorySpaPackage.GetAllAsync(x => x.IsDeleted == false, x => x.PackageServices);
        }

        public async Task<SpaPackageDetailResponse> GetSpaPackageByID(int id)
        {
            var spaPackage = await _genericRepositorySpaPackage.GetByIdAsync(id, x => x.IsDeleted == false);
            if (spaPackage == null)
                throw new Exception("Package not found");

            var packageServices = await _genericRepositoryPackageService.GetAllAsync(x => x.SpaPackageId == id && x.IsDeleted == false, x => x.Service, x => x.Service.Weight);
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

        public async Task<string> DeleteSpaPackage(int id)
        {
            var spaPackage = await _genericRepositorySpaPackage.GetByIdAsync(id, x => x.IsDeleted == false);
            if (spaPackage == null)
                return "Service not found";

            var packageServices = await _genericRepositoryPackageService.GetAllAsync(x => x.SpaPackageId == spaPackage.Id && x.IsDeleted == false);

            foreach (var packageService in packageServices)
            {
                var PackageServiceToRemove = await _genericRepositoryPackageService.GetByIdAsync(packageService.Id);
                _genericRepositoryPackageService.SoftRemove(PackageServiceToRemove);
            }

            _genericRepositorySpaPackage.SoftRemove(spaPackage);
            if (await _genericRepositorySpaPackage.SaveChangesAsync() > 0)
                return "Delete Successfully";
            else
                return "Delete Failed";
        }

        public async Task<string> UpdateSpaPackage(int id, SpaPackage spaPackage, List<int> serviceIds)
        {
            try
            {
                if (spaPackage == null)
                    throw new Exception("Package Information is null");

                if (!serviceIds.Any())
                    throw new Exception("No Service selected");

                var existingSpaPackage = await _genericRepositorySpaPackage.GetByIdAsync(id, x => x.IsDeleted == false);
                if (existingSpaPackage == null)
                    throw new Exception("Package not found");

                existingSpaPackage.Name = spaPackage.Name;
                existingSpaPackage.Description = spaPackage.Description;
                existingSpaPackage.Price = spaPackage.Price;
                existingSpaPackage.PictureUrl = spaPackage.PictureUrl;
                existingSpaPackage.EstimatedTime = spaPackage.EstimatedTime;

                _genericRepositorySpaPackage.Update(existingSpaPackage);
                await _genericRepositorySpaPackage.SaveChangesAsync();

                var existingPackageServices = await _genericRepositoryPackageService.GetAllAsync(x => x.SpaPackageId == existingSpaPackage.Id && x.IsDeleted == false);

                // Lấy danh sách ID từ PackageService
                var existingServiceIds = existingPackageServices.Select(x => x.ServiceId.Value).ToList();

                // Tìm các ID cần xóa (có trong existingServiceIds nhưng không có trong serviceIds)
                var serviceIdsToRemove = existingServiceIds.Except(serviceIds).ToList();

                // Tìm các ID cần thêm (có trong serviceIds nhưng không có trong existingServiceIds)
                var serviceIdsToAdd = serviceIds.Except(existingServiceIds).ToList();

                if (serviceIdsToRemove.Any() && serviceIdsToAdd.Any())
                {
                    // Xóa các dịch vụ không còn trong danh sách mới
                    foreach (var serviceIdToRemove in serviceIdsToRemove)
                    {
                        var packageServiceToRemove = existingPackageServices.First(x => x.ServiceId == serviceIdToRemove);
                        _genericRepositoryPackageService.SoftRemove(packageServiceToRemove);
                    }

                    // Thêm các dịch vụ mới vào danh sách
                    foreach (var serviceIdToAdd in serviceIdsToAdd)
                    {
                        var packageService = new PackageService
                        {
                            SpaPackageId = existingSpaPackage.Id,
                            ServiceId = serviceIdToAdd
                        };
                        await _genericRepositoryPackageService.AddAsync(packageService);
                    }

                    if (await _genericRepositoryPackageService.SaveChangesAsync() > 0)
                        return "Update Successfully";
                    else
                        throw new Exception("Update Failed");
                }
                return "Update Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Update Failed: " + ex.Message);
            }
        }
    }
}