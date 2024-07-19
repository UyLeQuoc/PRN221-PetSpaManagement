using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Users
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<IndexModel> _logger;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IPetService _petService;

        public IndexModel(IAppointmentService appointmentService, ILogger<IndexModel> logger, IPaymentService paymentService, IUserService userService, IPetService petService)
        {
            _appointmentService = appointmentService;
            _logger = logger;
            _paymentService = paymentService;
            _userService = userService;
            _petService = petService;
        }

        [BindProperty]
        public User User { get; set; }

        public async Task OnGet()
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (string.IsNullOrEmpty(email))
                {
                    TempData["ErrorMessage"] = "Please login to use this function"; // (Chỉ trong môi trường development)
                    RedirectToPage("/LoginPage"); // Chuyển hướng về Index của Appointment
                }
                User = await _userService.GetUserByEmailAsync(email);
                ViewData["UserId"] = new SelectList(new[] { User }, "Id", "Email");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                Console.Write(ex.ToString());
                RedirectToPage("./Index");
            }
        }
    }
}