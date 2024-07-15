using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.SpaPackages
{
    public class IndexModel : PageModel
    {
        private readonly ISpaPackageService _spaPackageService;

        public IndexModel(ISpaPackageService spaPackageService)
        {
            _spaPackageService = spaPackageService;
        }

        public IList<SpaPackage> SpaPackages { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (await _spaPackageService.GetSpaPackages() != null)
            {
                SpaPackages = await _spaPackageService.GetSpaPackages();
            }
        }
    }
}
