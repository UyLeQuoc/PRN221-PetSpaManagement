using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPetService _petService;
        private readonly ISpaPackageService _spaPackageService;
        private readonly IUserService _userService; // Nếu bạn cần lấy thông tin User
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(IAppointmentService appointmentService,
                          IPetService petService,
                          ISpaPackageService spaPackageService,
                          IUserService userService, // Nếu bạn cần lấy thông tin User
                          ILogger<CreateModel> logger)
        {
            _appointmentService = appointmentService;
            _petService = petService;
            _spaPackageService = spaPackageService;
            _userService = userService;
            _logger = logger;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (string.IsNullOrEmpty(email))
                {
                    throw new Exception("The user id is null");
                }

                // Lấy danh sách user, pet, spa package (tương tự như trong EditModel)
                var user = await _userService.GetUserByEmailAsync(email);
                ViewData["UserId"] = new SelectList(new[] { user }, "Id", "Email");
                ViewData["PetId"] = new SelectList(await _petService.GetAllPets(), "Id", "Name");

                var allSpaPackages = await _spaPackageService.GetSpaPackages();
                ViewData["SpaPackageId"] = new SelectList(allSpaPackages, "Id", "Name");
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a new appointment.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index"); // Chuyển hướng về Index của Appointment
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return RedirectToPage();
                //}
                var result = await _appointmentService.CreateNewAppointment(Appointment);
                if (result == null)
                {
                    TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình tạo appointment.";
                    return RedirectToPage("./Index");
                }
                TempData["SuccessMessage"] = "Appointment đã được tạo thành công.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a product.");
                TempData["ErrorDetails"] = ex.ToString();
                return RedirectToPage("./Index");
            }
        }
    }
}