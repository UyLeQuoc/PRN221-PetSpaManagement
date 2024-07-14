using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.SpaPackages
{
    public class IndexModel : PageModel
    {
        private readonly ISpaPackageService _spaPackageService;

        public IndexModel(ISpaPackageService spaPackageService)
        {
            _spaPackageService = spaPackageService;
        }

        public IList<SpaPackage> SpaPackage { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (await _spaPackageService.GetSpaPackages() != null)
            {
                SpaPackage = await _spaPackageService.GetSpaPackages();
            }
        }
    }
}
