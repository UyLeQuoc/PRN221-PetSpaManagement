using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public User Customer { get; set; }

        public List<Role> Roles { get; set; }

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            // Static roles
            Roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "PetSitter" },
                new Role { Id = 4, Name = "Customer" }
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userService.AddAsync(Customer);
            return RedirectToPage("./Index");
        }
    }
}
