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

        public void OnGet(string role)
        {
            // Static roles
            Roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "PetSitter" },
                new Role { Id = 4, Name = "Customer" }
            };

            if (!string.IsNullOrEmpty(role))
            {
                var selectedRole = Roles.FirstOrDefault(r => r.Name.Equals(role, System.StringComparison.OrdinalIgnoreCase));
                if (selectedRole != null)
                {
                    Customer = new User { RoleId = selectedRole.Id };
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Re-populate the Roles list in case of an error
                Roles = new List<Role>
                {
                    new Role { Id = 1, Name = "Admin" },
                    new Role { Id = 2, Name = "Manager" },
                    new Role { Id = 3, Name = "PetSitter" },
                    new Role { Id = 4, Name = "Customer" }
                };
                return Page();
            }

            await _userService.AddAsync(Customer);
            TempData["Message"] = "User created successfully!";
            return RedirectToPage("./Index");
        }
    }
}
