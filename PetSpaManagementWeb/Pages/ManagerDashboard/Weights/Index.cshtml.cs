using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.Weights
{
    public class IndexModel : PageModel
    {
        private readonly IWeightService _weightService;

        public IndexModel(IWeightService weightService)
        {
            _weightService = weightService;
        }

        public IList<Weight> Weight { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (await _weightService.GetWeights() != null)
            {
                Weight = await _weightService.GetWeights();
            }
        }

    }
}
