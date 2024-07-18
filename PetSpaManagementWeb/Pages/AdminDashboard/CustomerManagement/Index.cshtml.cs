using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard.CustomerManagement
{
    public class IndexModel : PageModel
    {
        //search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }
        //paging
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;

        public List<User> Customers { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _userService.GetUsersByRoleIdAsync(4, searchTerm, pageIndex, PageSize);

            Customers = result.Users;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            TempData["Message"] = "User deleted successfully!";
            return RedirectToPage();
        }
    }
}
