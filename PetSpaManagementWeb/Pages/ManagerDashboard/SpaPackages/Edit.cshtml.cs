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
        private readonly IServiceService _serviceService;
        private readonly IStorageService _storageService;

        [BindProperty]
        public SpaPackageDetailResponse SpaPackageDetailResponse { get; set; }
        [BindProperty]
        public SpaPackage SpaPackage { get; set; }

        [BindProperty]
        public List<int> SelectedServiceIds { get; set; }
        [BindProperty]
        public IFormFile Picture { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public int? EstimatedTime { get; set; }

        public string ErrorMessage { get; set; }

        public EditModel(ISpaPackageService spaPackageService, IServiceService serviceService, IStorageService storageService)
        {
            _spaPackageService = spaPackageService;
            _serviceService = serviceService;
            _storageService = storageService;
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

            Services = await _serviceService.GetService();

            return Page();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            try
            {
                string pictureUrl = SpaPackageDetailResponse.SpaPackage.PictureUrl;

                if (SpaPackageDetailResponse.SpaPackage.Name == null)
                {
                    ErrorMessage = "Name is required.";
                }
                else if (SpaPackageDetailResponse.SpaPackage.Price == null)
                {
                    ErrorMessage = "Price is required.";
                }
                else
                {
                    if (Picture != null)
                    {
                        if(SpaPackageDetailResponse.SpaPackage.PictureUrl != null)
                        {
                            await _storageService.DeleteAsync(SpaPackageDetailResponse.SpaPackage.PictureUrl);
                        }

                        pictureUrl = await _storageService.UploadAsync(Picture);
                    }

                    SpaPackage.Name = SpaPackageDetailResponse.SpaPackage.Name;
                    SpaPackage.Description = SpaPackageDetailResponse.SpaPackage.Description;
                    SpaPackage.Price = SpaPackageDetailResponse.SpaPackage.Price;
                    SpaPackage.PictureUrl = pictureUrl;
                    SpaPackage.EstimatedTime = SpaPackageDetailResponse.SpaPackage.EstimatedTime;

                    await _spaPackageService.UpdateSpaPackage(id, SpaPackage, SelectedServiceIds);
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
