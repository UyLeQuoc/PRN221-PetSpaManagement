using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.PetSitterDashboard
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;

        public IndexModel(IAppointmentService appointmentService, IUserService userService ) 
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
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("The user id is null");
            }
            var user = await _userService.GetUserByEmailAsync(email);
            if (await _appointmentService.GetPetSitterAppointments(user.Id) != null)
            {
                Appointment = await _appointmentService.GetPetSitterAppointments(user.Id);
            }
        }
    }
}
