using AutoMapper.Execution;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.Pets
{
    public class IndexModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly ILogger<EditModel> _logger; // Inject ILogger nếu cần

        public IndexModel(IPetService petService, ILogger<EditModel> logger)
        {
            _petService = petService;
            _logger = logger;
        }

        public IList<Pet> Pets { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                Pets = await _petService.GetAllPets();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                Console.Write(ex.ToString());
                RedirectToPage();
            }
        }
    }
}