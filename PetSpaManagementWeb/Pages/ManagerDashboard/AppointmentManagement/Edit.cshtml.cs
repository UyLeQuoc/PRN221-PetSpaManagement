using Amazon.S3.Model;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.AppointmentManagement
{
    public class EditModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly ISpaPackageService _spaPackageService;
        private readonly IPetService _petService;

        public EditModel(IAppointmentService appointmentService,
                         IUserService userService,
                         ISpaPackageService spaPackageService,
                         IPetService petService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
            _spaPackageService = spaPackageService;
            _petService = petService;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _appointmentService.GetAppointments() == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            Appointment = appointment;
            ViewData["UserId"] = new SelectList(await _userService.GetUsersByRoleIdAsync(4), "Id", "Name");
            ViewData["SpaPackageId"] = new SelectList(await _spaPackageService.GetSpaPackages(), "Id", "Name");
            ViewData["PetId"] = new SelectList(await _petService.GetAllPets(), "Id", "Name");
            ViewData["PetSitter"] = new SelectList(await _userService.GetUsersByRoleIdAsync(3), "Id", "Name");
            return Page();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            try
            {
                await _appointmentService.UpdateAppoiment(Appointment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Esited(Appointment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Esited(int id)
        {
            return _appointmentService.GetAppointmentById(id) != null;
        }
    }
}
