using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.PetSitterDashboard
{
    public class EditModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public EditModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Appointment = await _appointmentService.GetAppointmentById(id);

            if (Appointment == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _appointmentService.UpdateAppointmentStatusAsync(Appointment.Id, Appointment.Status);

            return RedirectToPage("/PetSitterDashboard/Index");
        }
    }
}
