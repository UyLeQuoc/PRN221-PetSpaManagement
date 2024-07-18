using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.ManagerDashboard
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;

        public IndexModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime StartDate { get; set; } = DateTime.Today.AddDays(-30);

        [BindProperty(SupportsGet = true)]
        public DateTime EndDate { get; set; } = DateTime.Today;

        public int UnassignedAppointmentsCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TodayAppointmentsCount { get; set; }
        public decimal TodayRevenue { get; set; }
        public List<string> Dates { get; set; } = new List<string>();
        public List<decimal> Revenues { get; set; } = new List<decimal>();

        public async Task OnGetAsync()
        {
            var appointments = await _appointmentService.GetAppointmentsByDateRange(StartDate, EndDate.AddDays(1));
            UnassignedAppointmentsCount = appointments.Count(a => a.PetSitterId == null);

            var payments = await _appointmentService.GetPaymentsByDateRange(StartDate, EndDate.AddDays(1));
            TotalRevenue = payments.Sum(p => p.TotalAmount);

            // Today's statistics
            var todayAppointments = await _appointmentService.GetAppointmentsByDateRange(DateTime.Today, DateTime.Today.AddDays(1));
            TodayAppointmentsCount = todayAppointments.Count();

            var todayPayments = await _appointmentService.GetPaymentsByDateRange(DateTime.Today, DateTime.Today.AddDays(1));
            TodayRevenue = todayPayments.Sum(p => p.TotalAmount);

            // Prepare data for the graph
            var groupedPayments = payments.GroupBy(p => p.PaymentDate?.Date)
                                          .Select(g => new { Date = g.Key, Total = g.Sum(p => p.TotalAmount) })
                                          .OrderBy(g => g.Date);

            foreach (var item in groupedPayments)
            {
                Dates.Add(item.Date?.ToString("yyyy-MM-dd") ?? "");
                Revenues.Add(item.Total);
            }
        }
    }
}
