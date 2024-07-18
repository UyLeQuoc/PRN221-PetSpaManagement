using AutoMapper;
using RepositoryLayer.Commons;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace ServiceLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IMapper mapper, IClaimsService claimsService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Payment> CreatePaymentAsync(Appointment appointment)
        {
            try
            {
                var newPayment = new Payment
                {
                    AppointmentId = appointment.Id,
                    PaymentMethod = "VNPAY",
                    PaymentDate = DateTime.UtcNow.AddHours(7),
                    Status = "PENDING",
                    UserId = _claimsService.GetCurrentSessionUserId,
                    TotalAmount = appointment.Price.Value
                };

                var check = await _unitOfWork.PaymentRepository.AddAsync(newPayment);
                var result = await _unitOfWork.SaveChangeAsync();
                if (result > 0)
                {
                    return check;
                }
                else
                {
                    throw new Exception("Something has been failed while adding payment");
                    //return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            var paymentsUser = await _unitOfWork.PaymentRepository.GetAllPaymentsAsync();
            if (_claimsService.GetCurrentSessionUserId == 0)
            {
                throw new Exception("Non-signup user");
            }
            return paymentsUser.Where(x => x.UserId == _claimsService.GetCurrentSessionUserId).ToList();
        }
    }
}