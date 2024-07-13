using Domain.Entities;
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
    }
}
