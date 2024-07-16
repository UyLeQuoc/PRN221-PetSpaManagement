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
                //await _appointmentService.DeleteAppointmentAsync(id); // Sửa lại method
                TempData["SuccessMessage"] = "Appointment đã được xóa thành công.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an appointment.");
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                return RedirectToPage("./Index");
            }
        }
    }
}