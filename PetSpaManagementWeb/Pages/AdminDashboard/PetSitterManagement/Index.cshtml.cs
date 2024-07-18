using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.AdminDashboard.PetSitterManagement
{
    public class IndexModel : PageModel
    {
        // Search
        [BindProperty(SupportsGet = true)]
        public string searchTerm { get; set; }
        // Paging
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 3;

        public List<User> PetSitters { get; set; }

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var result = await _userService.GetUsersByRoleIdAsync(3, searchTerm, pageIndex, PageSize);

            PetSitters = result.Users;
            PageIndex = result.PageIndex;
            TotalPages = result.TotalPages;
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            TempData["Message"] = $"Deleting PetSitter with ID: {id}";
            await _userService.DeleteAsync(id);
            TempData["Message"] = "PetSitter deleted successfully!";
            return RedirectToPage();
        }
    }
}
