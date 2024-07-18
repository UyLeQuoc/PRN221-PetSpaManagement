using Domain.Entities;
using ServiceLayer.ViewModels.PaymentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePaymentAsync(Appointment appointment);
        Task<PaymentResult> CreateTransactionOfPaymentAsync(PaymentResponseModel response);
        Task<List<Payment>> GetPaymentByAppointmentIdAsync(int id);
        Task<List<Payment>> GetPaymentsAsync();
    }
}