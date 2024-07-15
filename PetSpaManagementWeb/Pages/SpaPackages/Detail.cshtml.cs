using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.SpaPackages
{
    public class DetailModel : PageModel
    {
        private readonly ISpaPackageService _spaPackageService;

        public DetailModel(ISpaPackageService spaPackageService)
        {
            _spaPackageService = spaPackageService;
        }

        public SpaPackageDetailResponse SpaPackageDetailResponse { get; set; } = default!;
        public string ErrorMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _spaPackageService.GetSpaPackages() == null)
            {
                return NotFound();
            }

            var spaPackageDetail = await _spaPackageService.GetSpaPackageByID(id);
            if (spaPackageDetail == null)
            {
                return NotFound();
            }
            else
            {
                SpaPackageDetailResponse = spaPackageDetail;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("Index");
        }
    }
}
