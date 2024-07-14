using Domain.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class SpaPackageService : ISpaPackageService
    {
        private readonly ISpaPackageRepository _spaPackageRrepository;

        public SpaPackageService(ISpaPackageRepository spaPackageRrepository)
        {
            _spaPackageRrepository = spaPackageRrepository;
        }

        public async Task<string> CreateSpaPackage(SpaPackage spaPackage, List<int> serviceIds)
        {
            return await _spaPackageRrepository.CreateSpaPackage(spaPackage, serviceIds);
        }

        public async Task<SpaPackageDetailResponse> GetSpaPackageByID(int id)
        {
            return await _spaPackageRrepository.GetSpaPackageByID(id);
        }

        public async Task<List<SpaPackage>> GetSpaPackages()
        {
            return await _spaPackageRrepository.GetSpaPackages(); 
        }
    }
}
