using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard
{
    public class IndexModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        // Inject ILogger nếu cần

        public IndexModel(IPetService petService, ILogger<IndexModel> logger, IUserService userService)
        {
            _petService = petService;
            _logger = logger;
            _userService = userService;
        }

        public void OnGet()
        {
        }
    }
}