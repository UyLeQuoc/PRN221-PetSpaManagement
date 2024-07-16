using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<IndexModel> _logger; // Inject ILogger nếu cần

        public IndexModel(IAppointmentService appointmentService, ILogger<IndexModel> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        public IList<Appointment> Appointments { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Appointments = await _appointmentService.GetAllAppointmentAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching appointments.");
                // Xử lý lỗi ở đây, ví dụ: hiển thị thông báo lỗi
            }
        }
    }
}