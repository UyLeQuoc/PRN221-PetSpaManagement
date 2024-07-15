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
        private readonly IServiceRepository _serviceRepository;

        [BindProperty]
        public SpaPackage SpaPackage { get; set; }

        [BindProperty]
        public List<int> SelectedServiceIds { get; set; }

        public IEnumerable<Service> Services { get; set; }

        public int? EstimatedTime { get; set; }

        public CreateModel(ISpaPackageService spaPackageService, IServiceRepository serviceRepository)
        {
            _spaPackageService = spaPackageService;
            _serviceRepository = serviceRepository;
            SelectedServiceIds = new List<int>();
        }

        public async Task OnGetAsync()
        {
            Services = await _serviceRepository.GetService();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _spaPackageService.CreateSpaPackage(SpaPackage, SelectedServiceIds);

            return RedirectToPage("Index");
        }
    }
}
