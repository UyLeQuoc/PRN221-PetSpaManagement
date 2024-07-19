using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Weights
{
    public class EditModel : PageModel
    {
        private readonly IWeightService _weightService;

        public EditModel(IWeightService weightService)
        {
            _weightService = weightService;
        }

        [BindProperty]
        public Weight Weight { get; set; } = default!;
        public string ErrorMessage { get; set; }

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
            Weight = weight;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(SeaArea).State = EntityState.Modified;

            try
            {
                if (Weight.FromWeight > Weight.ToWeight)
                {
                    ErrorMessage = "From Weight must be less than To Weight";

                }
                else if (Weight.FromWeight <= 0)
                {
                    ErrorMessage = "From Weight must be more than 0";
                }
                else if (Weight.ToWeight <= 0)
                {
                    ErrorMessage = "To Weight must be more than 0";
                }
                else
                {
                    await _weightService.UpdateWeight(id, Weight);
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}

