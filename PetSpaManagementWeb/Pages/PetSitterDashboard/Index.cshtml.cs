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

        public IList<Appointment> Appointment { get; set; } = default!;
        public async Task OnGetAsync()
        {

            if (await _appointmentService.GetPetSitterAppointments() != null)
            {
                Appointment = await _appointmentService.GetAppointments();
                //Appointment = await _appointmentService.GetPetSitterAppointments();
            }
        }
    }
}
