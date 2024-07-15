using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.SpaPackages
{
    public class EditModel : PageModel
    {
        private readonly ISpaPackageService _spaPackageService;
        private readonly IServiceRepository _serviceRepository;

        [BindProperty]
        public SpaPackageDetailResponse SpaPackageDetailResponse { get; set; }
        [BindProperty]
        public SpaPackage SpaPackage { get; set; }

        [BindProperty]
        public List<int> SelectedServiceIds { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public int? EstimatedTime { get; set; }

        public EditModel(ISpaPackageService spaPackageService, IServiceRepository serviceRepository)
        {
            _spaPackageService = spaPackageService;
            _serviceRepository = serviceRepository;
            SelectedServiceIds = new List<int>();
        }

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
            SpaPackageDetailResponse = spaPackageDetail;

            // Để hiển thị check có sẵn của spaPackage trong Services LIst
            SelectedServiceIds = spaPackageDetail.Services.Select(s => s.Id).ToList();

            Services = await _serviceRepository.GetService();

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            try
            {
                SpaPackage.Name = SpaPackageDetailResponse.SpaPackage.Name;
                SpaPackage.Description = SpaPackageDetailResponse.SpaPackage.Description;
                SpaPackage.Price = SpaPackageDetailResponse.SpaPackage.Price;
                SpaPackage.PictureUrl = SpaPackageDetailResponse.SpaPackage.PictureUrl;
                SpaPackage.EstimatedTime = SpaPackageDetailResponse.SpaPackage.EstimatedTime;

                await _spaPackageService.UpdateSpaPackage(id, SpaPackage, SelectedServiceIds);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
