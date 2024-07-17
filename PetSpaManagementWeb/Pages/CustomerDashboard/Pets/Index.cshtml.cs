using AutoMapper.Execution;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Commons;
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

        //search
        [BindProperty(SupportsGet = true)]
        public string? searchString { get; set; } // chưa làm

        //pagin
        public Pagination<Pet> pagination { get; set; }

        public PaginationParameter parameter { get; set; }

        public IList<Pet> Pets { get; set; }

        public async Task OnGetAsync(int pageIndex = 1)
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

                parameter = new PaginationParameter()
                {
                    PageIndex = pageIndex,
                };
                pagination = await _petService.GetAllPetsFilter(searchString, parameter);
                Pets = pagination.Where(x => x.UserId == user.Id).ToList();
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