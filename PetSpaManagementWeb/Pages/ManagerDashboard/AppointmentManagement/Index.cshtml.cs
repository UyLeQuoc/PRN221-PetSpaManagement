using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.AppointmentManagement
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public IndexModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IList<Appointment> Appointment { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (await _appointmentService.GetAppointments() != null)
            {
                Appointment = await _appointmentService.GetAppointments();
            }
        }
    }
}
