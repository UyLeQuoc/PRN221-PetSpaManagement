using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Weights
{
    public class DeleteModel : PageModel
    {
        private readonly IWeightService? _weightService;

        public DeleteModel(IWeightService? weightService)
        {
            _weightService = weightService;
        }

        [BindProperty]
        public Weight Weight { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _weightService.GetWeights() == null)
            {
                return NotFound();
            }

            var weight = await _weightService.GetWeightById(id);

            if (weight == null)
            {
                return NotFound();
            }
            else
            {
                Weight = weight;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || await _weightService.GetWeights() == null)
            {
                return NotFound();
            }

            await _weightService.DeleteWeight(id);
      

            return RedirectToPage("./Index");
        }
    }
}
