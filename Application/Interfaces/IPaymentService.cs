using Domain.Entities;
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
        Task<List<Payment>> GetPaymentsAsync();
    }
}