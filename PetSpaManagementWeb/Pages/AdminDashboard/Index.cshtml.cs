using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public Dictionary<string, int> UserCounts { get; set; }

        public async Task OnGetAsync()
        {
            UserCounts = await _userService.GetUserCountsByRoleAsync();
        }
    }
}
