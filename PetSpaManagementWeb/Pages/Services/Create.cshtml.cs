using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PetSpaManagementWeb.Pages.Services
{
    public class CreateModel : PageModel
    {
        private readonly IServiceService _serviceService;

        public CreateModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        [TempData]
        public string ResultMessage { get; set; }

        [TempData]
        public string ResultMessageType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid /*|| _serviceService.GetSeaAreas() == null*/ || Service == null)
            {
                return Page();
            }

            //try
            //{
            //    ResultMessage = await _serviceService.CreateService(Service);
            //    ResultMessageType = "success"; 
            //}
            //catch (Exception ex)
            //{
            //    ResultMessage = ex.Message;
            //    ResultMessageType = "error"; 
            //}

            return RedirectToPage("./Index");
        }
    }
}
