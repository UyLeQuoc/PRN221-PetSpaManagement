using AutoMapper.Execution;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Pets
{
    public class IndexModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly ILogger<EditModel> _logger;
        private readonly IUserService _userService;
        // Inject ILogger nếu cần

        public IndexModel(IPetService petService, ILogger<EditModel> logger, IUserService userService)
        {
            _petService = petService;
            _logger = logger;
            _userService = userService;
        }

        public IList<Pet> Pets { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (string.IsNullOrEmpty(email))
                {
                    TempData["ErrorMessage"] = "Please login to use this function"; // (Chỉ trong môi trường development)
                    RedirectToPage("/LoginPage"); // Chuyển hướng về Index của Appointment
                }
                var user = await _userService.GetUserByEmailAsync(email);
                var data = await _petService.GetAllPets();
                Pets = data.Where(x => x.UserId == user.Id).ToList();
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