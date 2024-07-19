using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<IndexModel> _logger; // Inject ILogger nếu cần
        private readonly IUserService _userService;

        public IndexModel(IAppointmentService appointmentService, ILogger<IndexModel> logger, IUserService userService)
        {
            _appointmentService = appointmentService;
            _logger = logger;
            _userService = userService;
        }

        public IList<Appointment> Appointments { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (string.IsNullOrEmpty(email))
                {
                    TempData["ErrorMessage"] = "Please login to use this function"; // (Chỉ trong môi trường development)
                    RedirectToPage("/LoginPage"); // Chuyển hướng về Index của Appointment
                }
                var user = await _userService.GetUserByEmailAsync(email);

                var data = await _appointmentService.GetAllAppointmentAsync();
                Appointments = data.OrderByDescending(x => x.DateTime).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching appointments.");
                // Xử lý lỗi ở đây, ví dụ: hiển thị thông báo lỗi
            }
        }
    }
}