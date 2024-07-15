using Amazon.S3.Model; // Nếu bạn cần sử dụng Amazon S3
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.Pets
{
    public class DeleteModel : PageModel
    {
        private readonly IPetService _petService;
        private readonly ILogger<DeleteModel> _logger; // Inject ILogger nếu cần

        public DeleteModel(IPetService petService, ILogger<DeleteModel> logger)
        {
            _petService = petService;
            _logger = logger;
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    throw new Exception("The pet id is null");
                }
                Pet = await _petService.GetPetById(id.Value);
                if (Pet == null)
                {
                    throw new Exception("Cannot find this pet");
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a pet.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index");
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var result = await _petService.DeletePetAsync(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Pet đã được xóa thành công.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình xóa pet.";
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a pet.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index");
            }
        }
    }
}