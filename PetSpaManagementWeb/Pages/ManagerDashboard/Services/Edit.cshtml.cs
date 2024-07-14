using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Services
{
    public class EditModel : PageModel
    {
        private readonly IServiceService _service;
        private readonly IWeightService _weightService;

        public EditModel(IServiceService service, IWeightService weightService)
        {
            _service = service;
            _weightService = weightService;
        }

        [BindProperty]
        public Service Service{ get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _service.GetService() == null)
            {
                return NotFound();
            }

            var service = await _service.GetServiceByID(id);
            if (service == null)
            {
                return NotFound();
            }
            Service = service;

            var weights = await _weightService.GetWeights();
            var weightSelectList = weights.Select(w => new
            {
                Id = w.Id,
                WeightDisplay = $"{w.FromWeight} - {w.ToWeight}kg"
            }).ToList();

            ViewData["WeightId"] = new SelectList(weightSelectList, "Id", "WeightDisplay");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            try
            {
                await _service.UpdateService(id, Service);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
