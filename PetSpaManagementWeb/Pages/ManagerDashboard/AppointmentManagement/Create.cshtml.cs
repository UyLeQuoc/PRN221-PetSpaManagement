using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.AppointmentManagement
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly ISpaPackageService _spaPackageService;
        private readonly IPetService _petService;

        public CreateModel(IAppointmentService appointmentService,
                           IUserService userService,
                           ISpaPackageService spaPackageService,
                           IPetService petService)
        {
            _appointmentService = appointmentService;
            _userService = userService;
            _spaPackageService = spaPackageService;
            _petService = petService;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["UserId"] = new SelectList(await _userService.GetUsersByRoleIdAsync(4), "Id", "Name");
            ViewData["SpaPackageId"] = new SelectList(await _spaPackageService.GetSpaPackages(), "Id", "Name");
            ViewData["PetId"] = new SelectList(await _petService.GetAllPets(), "Id", "Name");
            ViewData["PetSitter"] = new SelectList(await _userService.GetUsersByRoleIdAsync(3), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _appointmentService.CreateNewAppointment(Appointment);

            return RedirectToPage("Index");
        }
    }
}
