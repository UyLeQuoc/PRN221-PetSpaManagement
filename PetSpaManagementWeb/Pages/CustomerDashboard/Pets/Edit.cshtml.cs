using Amazon.S3.Model;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Pets
{
    public class EditModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly IUserService _userService;
        private readonly ILogger<EditModel> _logger; // Inject ILogger nếu cần

        public EditModel(IPetService petService, IUserService userService, ILogger<EditModel> logger)
        {
            _petService = petService;
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (!id.HasValue || string.IsNullOrEmpty(email))
                {
                    throw new Exception("The user id is null");
                }
                Pet = await _petService.GetPetById(id.Value);
                if (Pet == null)
                {
                    throw new Exception("Cannot find this pet");
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
                if (!ModelState.IsValid) // Kiểm tra xem dữ liệu có hợp lệ không
                {
                    return Page(); // Nếu không hợp lệ, quay lại trang chỉnh sửa
                }

                var result = await _petService.UpdatePetAsync(Pet); // Gọi phương thức cập nhật pet trong Service

                if (result == null) // Kiểm tra xem cập nhật có thành công không
                {
                    TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình cập nhật pet.";
                }
                else
                {
                    TempData["SuccessMessage"] = "Pet đã được cập nhật thành công.";
                }

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