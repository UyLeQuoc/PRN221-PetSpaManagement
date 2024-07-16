using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.UserManagement
{
    public class DetailModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPetService _petService;
        private readonly IUserService _userService;

        public DetailModel(IAppointmentService appointmentService , IPetService petService, IUserService userService)
        {
            _appointmentService = appointmentService;
            _petService = petService;
            _userService = userService;
        }

        public IList<Pet> Pets { get; set; }
        public IList<Appointment> Appointment { get; set; } = default!;
        public IList<User> PetSitters { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            var petSitter = await _userService.GetUsersByRoleIdAsync(3);
            if (petSitter != null)
            {
                PetSitters = petSitter;
            }
            try
            {
                Pets = await _petService.GetAllPetsByUserId(id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); 
                Console.Write(ex.ToString());
                RedirectToPage();
            }

            if (await _appointmentService.GetAppointmentsByUserId(id) != null)
            {
                Appointment = await _appointmentService.GetAppointmentsByUserId(id);
            }
        }
    }
}
