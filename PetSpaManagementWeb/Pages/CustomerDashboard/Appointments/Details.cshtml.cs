using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using ServiceLayer.Services.VnPayConfig;
using ServiceLayer.ViewModels.PaymentDTOs;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Appointments
{
    public class DetailsModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ILogger<DetailsModel> _logger;
        private readonly IPaymentService _paymentService;
        private readonly IVnPayService _vnPayService;

        public DetailsModel(IAppointmentService appointmentService, ILogger<DetailsModel> logger, IPaymentService paymentService, IVnPayService vnPayService)
        {
            _appointmentService = appointmentService;
            _logger = logger;
            _paymentService = paymentService;
            _vnPayService = vnPayService;
        }

        public Appointment Appointment { get; set; } = default!;
        private string status { get; set; } = string.Empty;

        public async Task OnGet(int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    Appointment = await _appointmentService.GetAppointmentById(id.Value);
                }
                else
                {
                    TempData["ErrorMessage"] = "Cannot find pet or empty ID value"; // (Chỉ trong môi trường development)
                    RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.ToString(); // (Chỉ trong môi trường development)
                Console.Write(ex.ToString());
                RedirectToPage("./Index");
            }
        }

        public async Task<IActionResult> OnPostPayAsync(int id)
        {
            try
            {
                var payment = await _paymentService.GetPaymentByAppointmentIdAsync(id);
                if (payment != null)
                {
                    var orderInfo = new VnpayOrderInfo
                    {
                        Amount = payment.First().TotalAmount,
                        AppointmentId = payment.First().AppointmentId,
                        PaymentId = payment.First().Id
                    };

                    var paymentUrl = _vnPayService.CreateLink(orderInfo); // trả về url thanh toán vnpay

                    if (paymentUrl == null)
                    {
                        TempData["ErrorMessage"] = "Đã có lỗi xảy ra trong quá trình tạo url.";
                        return RedirectToPage("./Index");
                    }
                    TempData["SuccessMessage"] = "Appointment đã được tạo thành công. Vui lòng thanh toán: ";
                    TempData["PaymentUrl"] = paymentUrl;
                    return Redirect(paymentUrl);
                }
                TempData["ErrorMessage"] = "Appointment chưa có payment";

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initiating the payment.");
                TempData["ErrorMessage"] = "An error occurred while initiating the payment.";
                return RedirectToPage();
            }
        }
    }
}