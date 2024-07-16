using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Pets
{
    public class CreateModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IUserService _userService;
        private readonly ILogger<EditModel> _logger; // Inject ILogger nếu cần

        public CreateModel(IPetService petService, IUserService userService, ILogger<EditModel> logger)
        {
            _petService = petService;
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("The user id is null");
                }

                var user = await _userService.GetUserByEmailAsync(email);
                ViewData["UserId"] = new SelectList(new[] { user }, "Id", "Email");

                var itemList = new List<SelectListItem>()
                {
                    new SelectListItem { Value = "Dog", Text = "Dog" },
                    new SelectListItem { Value = "Cat", Text = "Cat" },
                    new SelectListItem { Value = "Hamster", Text = "Hamster" }
                                };

                ViewData["Type"] = new SelectList(itemList, "Value", "Text");

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a product.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                var result = await _petService.CreatePetAsync(Pet);
                if (result == null)
                {
                    TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình tạo pet.";
                    return RedirectToPage("./Index"); // Hoặc bạn có thể trả về Page() để giữ lại trên trang Create
                }
                TempData["SuccessMessage"] = "Pet đã được tạo thành công.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a product.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index");
            }
        }
    }
}