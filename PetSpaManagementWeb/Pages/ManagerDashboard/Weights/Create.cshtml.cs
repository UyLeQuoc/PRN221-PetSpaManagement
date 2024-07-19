using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Weights
{
    public class CreateModel : PageModel
    {
        private readonly IWeightService _weightService;

        public CreateModel(IWeightService weightService)
        {
            _weightService = weightService;
        }

        public void OnGet()
        {
        }


        [BindProperty]
        public Weight Weight { get; set; } = default!;
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || await _weightService.GetWeights() == null || Weight == null)
            {
                return Page();
            }

            try
            {
                if (Weight.FromWeight > Weight.ToWeight)
                {
                    ErrorMessage= "From Weight must be less than To Weight";
                    return Page();

                }
                else if( Weight.FromWeight <= 0)
                {
                    ErrorMessage = "From Weight must be more than 0";
                    return Page();
                }
                else if (Weight.ToWeight <= 0)
                {
                    ErrorMessage = "To Weight must be more than 0";
                    return Page();
                }
                else
                {
                    await _weightService.CreateWeight(Weight);
                    return RedirectToPage("./Index");
                }
                
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            return Page();
        }
    }
}
