using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.SpaPackages
{
    public class DeleteModel : PageModel
    {
        private readonly ISpaPackageService _spaPackageService;

        public DeleteModel(ISpaPackageService spaPackageService)
        {
            _spaPackageService = spaPackageService;
        }

        [BindProperty]
        public SpaPackageDetailResponse SpaPackageDetailResponse { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _spaPackageService.GetSpaPackages() == null)
            {
                return NotFound();
            }

            var spaPackage = await _spaPackageService.GetSpaPackageByID(id);

            if (spaPackage == null)
            {
                return NotFound();
            }
            else
            {
                SpaPackageDetailResponse = spaPackage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || await _spaPackageService.GetSpaPackages() == null)
            {
                return NotFound();
            }

            await _spaPackageService.DeleteSpaPackage(id);


            return RedirectToPage("./Index");
        }
    }
}
