using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.PetSitterManagement
{
    public class DetailModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;

        public DetailModel(IAppointmentService appointmentService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
        }
        public IList<Appointment> Appointment { get; set; } = default!;
        public IList<User> PetSitters { get; set; } = default!;


        public async Task OnGetAsync(int id)
        {
            var petSitter = await _userService.GetUsersByRoleIdAsync(3);
            if (petSitter != null)
            {
                PetSitters = petSitter;
            }
            if (await _appointmentService.GetAppointmentsByPetSitterId(id) != null)
            {
                Appointment = await _appointmentService.GetAppointmentsByPetSitterId(id);
            }
        }
    }
}
