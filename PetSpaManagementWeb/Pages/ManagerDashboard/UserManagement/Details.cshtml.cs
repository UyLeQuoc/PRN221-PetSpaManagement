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

        public DetailModel(IAppointmentService appointmentService , IPetService petService)
        {
            _appointmentService = appointmentService;
            _petService = petService;
        }

        public IList<Pet> Pets { get; set; }
        public IList<Appointment> Appointment { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
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
