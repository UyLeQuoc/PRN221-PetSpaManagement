using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard.ManagerManagement
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

        public List<User> Managers { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _userService.GetUsersByRoleIdAsync(2, searchTerm, pageIndex, PageSize);

            Managers = result.Users;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
            TempData["Message"] = "Manager deleted successfully!";
            return RedirectToPage();
        }
    }
}
