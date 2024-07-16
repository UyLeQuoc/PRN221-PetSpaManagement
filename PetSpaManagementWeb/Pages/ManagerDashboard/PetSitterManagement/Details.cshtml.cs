using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.PetSitterManagement
{
    public class DetailModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public DetailModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IList<Appointment> Appointment { get; set; } = default!;

        public async Task OnGetAsync()
        {

            if (await _appointmentService.GetPetSitterAppointments() != null)
            {
                Appointment = await _appointmentService.GetPetSitterAppointments();
            }
        }
    }
}
