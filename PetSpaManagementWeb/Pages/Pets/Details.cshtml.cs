using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.Pets
{
    public class DetailsModel : PageModel
    {
        private readonly IPetService _petService;

        public DetailsModel(IPetService petService)
        {
            _petService = petService;
        }

        public Pet Pet { get; set; } = default!;

        public async Task OnGet(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Pet = await _petService.GetPetById(id.Value);
                }
                else
                {
                    TempData["ErrorMessage"] = "Cannot find pet or empty ID value"; // (Chỉ trong môi trường development)
                    RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                Console.Write(ex.ToString());
                RedirectToPage("./Index");
            }
        }
    }
}