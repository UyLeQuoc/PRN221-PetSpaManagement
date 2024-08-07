using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.SpaPackages
{
    public class CreateModel : PageModel
    {
        private readonly ISpaPackageService _spaPackageService;
        private readonly IServiceService _serviceService;
        private readonly IStorageService _storageService;

        [BindProperty]
        public SpaPackage SpaPackage { get; set; }

        [BindProperty]
        public List<int> SelectedServiceIds { get; set; }

        [BindProperty]
        public IFormFile Picture { get; set; }

        public string ErrorMessage { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public int? EstimatedTime { get; set; }

        public CreateModel(ISpaPackageService spaPackageService, IServiceService serviceService, IStorageService storageService)
        {
            _spaPackageService = spaPackageService;
            _serviceService = serviceService;
            _storageService = storageService;
            SelectedServiceIds = new List<int>();
        }

        public async Task OnGetAsync()
        {
            Services = await _serviceService.GetService();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try 
            {
                if (SpaPackage.Name == null)
                {
                    ErrorMessage = "Name is required.";
                    Services = await _serviceService.GetService();
                    return Page();
                }
                else if (!SpaPackage.Price.HasValue || SpaPackage.Price <= 0)
                {
                    ErrorMessage = "Price is not empty and more than 0.";
                    Services = await _serviceService.GetService();
                    return Page();
                }
                else if (Picture == null)
                {
                    ErrorMessage = "Picture is required.";
                    Services = await _serviceService.GetService();
                    return Page();
                }
                else if(SelectedServiceIds.Count == 0)
                {
                    ErrorMessage = "Services is required.";
                    Services = await _serviceService.GetService();
                    return Page();
                }
                else
                {
                    SpaPackage.PictureUrl = await _storageService.UploadAsync(Picture);
                    await _spaPackageService.CreateSpaPackage(SpaPackage, SelectedServiceIds);
                }

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }

        }
    }
}
