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

        public IList<Appointment> Appointments { get; set; } = default!;
        public int paidQuantity { get; set; } = 0;
        public int unPaidQuantity { get; set; } = 0;

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

                var data = await _appointmentService.GetAllAppointmentAsync();
                Appointments = data
            .OrderByDescending(x => x.Status == "ASSIGNING") // Ưu tiên ASSIGNING
            .ThenBy(x => x.Status == "ASSIGNED")   // Ưu tiên ASSIGNED
            .ThenBy(x => x.DateTime)              // Sau đó sắp xếp theo CreatedAt
            .ToList();
                paidQuantity = Appointments.Count;
                unPaidQuantity = Appointments.Where(x => x.Status == "UNPAID").Count();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                Console.Write(ex.ToString());
                RedirectToPage("./Index");
            }
        }

        public async Task<IActionResult> OnPostAsync(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(User.Email);
                user.Name = User.Name;
                var result = await _userService.UpdateAsync(user);
                if (!result)
                {
                    TempData["ErrorMessage"] = "Update error";
                }
                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }
    }
}