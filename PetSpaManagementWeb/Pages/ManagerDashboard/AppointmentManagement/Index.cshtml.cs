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
        private readonly IUserService _userService;

        public IndexModel(IAppointmentService appointmentService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
        }

        public IList<Appointment> Appointment { get; set; } = default!;
        public IList<User> PetSitters { get; set; } = default!;
            
        public async Task OnGetAsync()
        {
            var petSitter = await _userService.GetUsersByRoleIdAsync(3);
            if (petSitter != null)
            {
                PetSitters = petSitter;
            }

            if (await _appointmentService.GetAppointments() != null)
            {
                Appointment = await _appointmentService.GetAppointments();

            }
        }
    }
}
