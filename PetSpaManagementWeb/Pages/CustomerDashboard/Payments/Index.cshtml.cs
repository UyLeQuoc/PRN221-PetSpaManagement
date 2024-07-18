using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepositoryLayer.Commons;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System.Reflection.Metadata;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Payments
{
    public class IndexModel : PageModel
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<IndexModel> _logger;
        private readonly IUserService _userService;
        // Inject ILogger nếu cần

        public IndexModel(IPaymentService petService, ILogger<IndexModel> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
            _paymentService = petService;
        }

        //search
        [BindProperty(SupportsGet = true)]
        public string? searchString { get; set; } // chưa làm

        //pagin
        public Pagination<Payment> pagination { get; set; }

        public PaginationParameter parameter { get; set; }

        public IList<Payment> Payments { get; set; }

        public async Task OnGetAsync()
        {
            try
            {
                var email = HttpContext.Session.GetString("Email");

                if (string.IsNullOrEmpty(email))
                {
                    TempData["ErrorMessage"] = "Please login to use this function"; // (Chỉ trong môi trường development)
                    RedirectToPage("/LoginPage"); // Chuyển hướng về Index của Appointment
                }
                //var user = await _userService.GetUserByEmailAsync(email);

                //parameter = new PaginationParameter()
                //{
                //    PageIndex = pageIndex,
                //};
                Payments = await _paymentService.GetPaymentsAsync();
                pagination = new Pagination<Payment>(Payments.ToList());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                Console.Write(ex.ToString());
                RedirectToPage();
            }
        }
    }
}