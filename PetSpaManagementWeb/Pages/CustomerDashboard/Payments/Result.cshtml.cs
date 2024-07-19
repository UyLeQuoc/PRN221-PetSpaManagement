using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;
using ServiceLayer.Services.VnPayConfig;

namespace PetSpaManagementWeb.Pages.CustomerDashboard.Payments
{
    public class ResultModel : PageModel
    {
        private readonly IPaymentService _paymentService;
        private readonly IVnPayService _vnPayService;
        private readonly ILogger<ResultModel> _logger; // Inject ILogger nếu cần

        public ResultModel(IPaymentService paymentService, IVnPayService vnPayService, ILogger<ResultModel> logger)
        {
            _paymentService = paymentService;
            _vnPayService = vnPayService;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                var pay = new VnPayLibrary();
                if (!Request.Query.Any())
                {
                    TempData["ErrorMessage"] = "KHÔNG CÓ GIAO DỊCH NÀO CẢ";
                }
                else
                {
                    var response = _vnPayService.GetFullResponseData(Request.Query);
                    var result = await _paymentService.CreateTransactionOfPaymentAsync(response);

                    if (response.Success)
                    {
                        if (response.VnPayResponseCode == "00")
                        {
                            TempData["PaymentSuccess"] = "THANH TOÁN CHO APPOINTMENT NO:" + result.Payment.AppointmentId + " THÀNH CÔNG";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "THANH TOÁN KHÔNG THÀNH CÔNG XIN HÃY THỬ LẠI: " + result.Payment.AppointmentId;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a product.");
                TempData["ErrorMessage"] = ex.ToString();
            }
        }
    }
}