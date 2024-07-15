using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard.ManagerManagement
{
    public class IndexModel : PageModel
    {
        public List<User> Managers { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync()
        {
            Managers = await _userService.GetUsersByRoleIdAsync(2);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}
