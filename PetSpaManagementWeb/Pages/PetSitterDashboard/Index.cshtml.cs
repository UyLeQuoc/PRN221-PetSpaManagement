using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.PetSitterDashboard
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public IndexModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IList<Appointment> Appointment { get; set; } = new List<Appointment>();

        public async Task OnGetAsync()
        {
            var petSitterId = HttpContext.Session.GetInt32("UserId") ?? -1;

            var re = await _appointmentService.GetAppointmentsByPetSitterId(petSitterId);
            if (re != null)
            {
                Appointment = re;
            }
        }

        public async Task<IActionResult> OnPostUpdateStatusAsync(int appointmentId, string status)
        {
            var result = await _appointmentService.UpdateAppointmentStatusAsync(appointmentId, status);
            if (result == "Status updated successfully")
            {
                var petSitterId = HttpContext.Session.GetInt32("UserId") ?? -1;
                Appointment = await _appointmentService.GetAppointmentsByPetSitterId(petSitterId);
            }
            else
            {
                // Handle error
            }
            return Page();
        }
    }
}
