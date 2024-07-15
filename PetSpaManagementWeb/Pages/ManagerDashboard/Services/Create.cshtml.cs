using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Services
{
    public class CreateModel : PageModel
    {
        private readonly IServiceService _serviceService;
        private readonly IWeightService _weightService;

        public CreateModel(IServiceService serviceService, IWeightService weightService)
        {
            _serviceService = serviceService;
            _weightService = weightService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var weights = await _weightService.GetWeights();
            var weightSelectList = weights.Select(w => new
            {
                Id = w.Id,
                WeightDisplay = $"{w.FromWeight} - {w.ToWeight}kg"
            }).ToList();

            ViewData["WeightId"] = new SelectList(weightSelectList, "Id", "WeightDisplay");
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; } = default!;

        [TempData]
        public string ResultMessage { get; set; }

        [TempData]
        public string ResultMessageType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if ( await _serviceService.GetService() == null || Service == null)
            {
                return Page();
            }

            try
            {
                ResultMessage = await _serviceService.CreateService(Service);
                ResultMessageType = "success";
            }
            catch (Exception ex)
            {
                ResultMessage = ex.Message;
                ResultMessageType = "error";
            }

            return RedirectToPage("./Index");
        }
    }
}
