using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Appointments
{
    public class DeleteModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(IAppointmentService appointmentService, ILogger<DeleteModel> logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    throw new Exception("The appointment id is null");
                }
                Appointment = await _appointmentService.GetAppointmentById(id.Value); // Sửa lại method
                if (Appointment == null)
                {
                    throw new Exception("Cannot find this appointment");
                }

                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an appointment.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index");
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                var result = await _appointmentService.CancelAppoimentById(id); // Sửa lại method
                if (result)
                {
                    TempData["SuccessMessage"] = "Appointment đã được hủy thành công.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Xóa apppointment thất bại, hãy thử lại.";
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an appointment.");
                if (ex.Message.Contains("Không thể hủy lịch hẹn"))
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình xóa lịch hẹn.";
                }
                return RedirectToPage("./Index");
            }
        }
    }
}