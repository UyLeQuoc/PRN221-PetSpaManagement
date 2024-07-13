using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Services
{
    public class IndexModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public IndexModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IList<Service> Service { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (await _serviceService.GetService() != null)
            {
                Service = await _serviceService.GetService();
            }
        }
    }
}
