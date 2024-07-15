using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard.AppointmentManagement
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IUserService _userService;
        private readonly ISpaPackageService _spaPackageService;
        //private readonly IPetService _petService;

        [BindProperty]
        public Appointment Appointment { get; set; }


        public CreateModel(IAppointmentService appointmentService,
                           IUserService userService,
                           ISpaPackageService spaPackageService
                           /*IPetService petService*/)
        {
            _appointmentService = appointmentService;
            _userService = userService;
            _spaPackageService = spaPackageService;
            //_petService = petService;
        }

        public async Task OnGetAsync()
        {
            ViewData["UserId"] = new SelectList(await _userService.GetCustomer(), "UserId", "Name");
            ViewData["SpaPackageId"] = new SelectList(await _spaPackageService.GetSpaPackages(), "SpaPackageId", "Name");
            //ViewData["PetId"] = new SelectList(await _petService.GetPets(), "PetId", "Name");
            ViewData["PetSitter"] = new SelectList(await _userService.GetPetSitter(), "UserId", "Name");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _appointmentService.CreateAppoiment(Appointment);

            return RedirectToPage("Index");
        }
    }
}
