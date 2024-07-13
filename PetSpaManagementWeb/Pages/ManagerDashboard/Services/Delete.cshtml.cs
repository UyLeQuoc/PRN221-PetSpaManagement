using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Services
{
    public class DeleteModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public DeleteModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _serviceService.GetService() == null)
            {
                return NotFound();
            }

            var service = await _serviceService.GetServiceByID(id);

            if (service == null)
            {
                return NotFound();
            }
            else
            {
                Service = service;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || await _serviceService.GetService() == null)
            {
                return NotFound();
            }
            var service = await _serviceService.GetServiceByID(id);

            if (service != null)
            {
                Service = service;
                await _serviceService.DeleteService(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
