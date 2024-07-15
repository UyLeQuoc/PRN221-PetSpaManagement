using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.AppointmentManagement
{
    public class DetailModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public DetailModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public Appointment Appointment { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _appointmentService.GetAppointments() == null)
            {
                return NotFound();
            }

            var appointmentDetail = await _appointmentService.GetAppointmentById(id);
            if (appointmentDetail == null)
            {
                return NotFound();
            }
            else
            {
                Appointment = appointmentDetail;
            }
            return Page();
        }
    }
}
