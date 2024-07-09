using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetSpaManagementWeb.Pages.Services
{
    public class DetailModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public DetailModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

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
    }
}
