using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard.CustomerManagement
{
    public class IndexModel : PageModel
    {
        public List<User> Customers { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Customers = await _userService.GetUsersByRoleIdAsync(4);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
