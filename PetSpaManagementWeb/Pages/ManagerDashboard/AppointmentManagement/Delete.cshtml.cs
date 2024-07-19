using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.AppointmentManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public DeleteModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || await _appointmentService.GetAppointments() == null)
            {
                return NotFound();
            }

            await _appointmentService.CancelAppoimentById(id);


            return RedirectToPage("./Index");
        }
    }
}
