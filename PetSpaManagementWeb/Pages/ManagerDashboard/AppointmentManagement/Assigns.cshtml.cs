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
    public class AssignModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;

        public AssignModel(IAppointmentService appointmentService,
                         IUserService userService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
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
                await _appointmentService.UpdateAppoimentStatus(Appointment);
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
