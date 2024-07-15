using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard.PetSitterManagement
{
    public class IndexModel : PageModel
    {
        public List<User> PetSitters { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            PetSitters = await _userService.GetUsersByRoleIdAsync(3);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
