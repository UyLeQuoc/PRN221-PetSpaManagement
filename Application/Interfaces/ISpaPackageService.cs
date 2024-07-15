using Domain.Entities;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ISpaPackageService
    {
        Task<string> CreateSpaPackage(SpaPackage spaPackage, List<int> serviceIds);
        Task<List<SpaPackage>> GetSpaPackages();
        Task<SpaPackageDetailResponse> GetSpaPackageByID(int id);
        Task<string> DeleteSpaPackage(int id);
        Task<string> UpdateSpaPackage(int id, SpaPackage spaPackage, List<int> serviceIds);
    }
}
