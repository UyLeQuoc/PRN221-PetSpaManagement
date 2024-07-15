using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public User Customer { get; set; }

        public List<Role> Roles { get; set; }

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _userService.GetByIdAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }

            // Static roles
            Roles = new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "PetSitter" },
                new Role { Id = 4, Name = "Customer" }
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                await _userService.UpdateAsync(Customer);
                TempData["Message"] = "User updated successfully!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }
    }
}
