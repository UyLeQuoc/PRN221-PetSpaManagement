using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public string? StatusFilter { get; set; }

        public SelectList StatusFilterItems { get; set; } = new SelectList(new List<SelectListItem>
{
    new SelectListItem { Value = "", Text = "All" },
    new SelectListItem { Value = "UNPAID", Text = "UNPAID" },
    new SelectListItem { Value = "ASSIGNING", Text = "ASSIGNING" },
    new SelectListItem { Value = "ASSIGNED", Text = "ASSIGNED" },
    new SelectListItem { Value = "COMPLETED", Text = "COMPLETED" },
    new SelectListItem { Value = "CANCELLED", Text = "CANCELLED" },
},"Value","Text");

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
                if (!string.IsNullOrEmpty(StatusFilter))
                {
                    Appointments = Appointments.Where(x => x.Status == StatusFilter).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching appointments.");
                // Xử lý lỗi ở đây, ví dụ: hiển thị thông báo lỗi
            }
        }
    }
}