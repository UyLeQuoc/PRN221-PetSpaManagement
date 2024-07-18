using AutoMapper;
using Domain.Entities;
using RepositoryLayer;
using RepositoryLayer.Commons;
using ServiceLayer.Interfaces;
using ServiceLayer.ViewModels.PaymentDTOs;

namespace ServiceLayer.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        private readonly IVnPayService _vpnPayService;

        public AppointmentService(IMapper mapper, IClaimsService claimsService, IUnitOfWork unitOfWork, IPaymentService paymentService, IVnPayService vpnPayService)
        {
            _mapper = mapper;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            _vpnPayService = vpnPayService;
        }

        public async Task<List<Appointment>> GetAppointments() // chưa có pagination
        {
            var list = await _unitOfWork.AppointmentRepository.GetAllAsync(a => a.IsDeleted == false,
                                                            a => a.User,
                                                            a => a.SpaPackage,
                                                            a => a.Pet);

            if (list == null)
                throw new Exception("Empty Appoiments");
            else
                return list;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(id);

            if (appointment == null)
                throw new Exception("No Appointment found");
            else
                return appointment;
        }

        public async Task<string> CreateNewAppointment(Appointment appointment)
        {
            try
            {
                var allSpapackage = await _unitOfWork.SpaPackageRepository.GetSpaPackages();
                var existingPackage = allSpapackage.FirstOrDefault(x => x.Id == appointment.SpaPackageId);

                if (existingPackage == null)
                {
                    throw new Exception("Non-existed spa package");
                }
                var existingPet = await _unitOfWork.PetRepository.GetByIdAsync(appointment.PetId);
                if (existingPackage == null)
                {
                    throw new Exception("Non-existed pet");
                }

                var newAppointment = new Appointment()
                {
                    UserId = appointment.UserId,
                    SpaPackageId = existingPackage.Id,
                    PetId = existingPet.Id,
                    DateTime = appointment.DateTime,
                    Status = "PENDING",
                    Notes = appointment.Notes,
                    Price = existingPackage.Price
                };

                appointment =await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    var payment = await _paymentService.CreatePaymentAsync(appointment);

                    if (payment != null)
                    {
                        var orderInfo = new VnpayOrderInfo
                        {
                            Amount = payment.TotalAmount,
                            AppointmentId = appointment.Id,
                        };

                        var url = _vpnPayService.CreateLink(orderInfo); // trả về url thanh toán vnpay

                        return url;
                    }
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateAppoiment(Appointment appointment)
        {
            var exist = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointment.Id, e => e.IsDeleted == false);
            if (exist == null)
                return "Service not found";

            var existingSpapackage = await _unitOfWork.SpaPackageRepository.GetSpaPackageByID(exist.SpaPackageId);
            if (existingSpapackage == null)
            {
                throw new Exception("Non-existed spa package");
            }
            if (appointment.Status == "PENDING" || appointment.Status == "ASSIGNED" || appointment.Status == "COMPLETED" || appointment.Status == "CANCELLED" || appointment.Status == "ABSENT")
            {
                throw new Exception("Invalid status");
            }

            exist.SpaPackageId = appointment.SpaPackageId;
            exist.PetId = appointment.PetId;
            exist.PetSitterId = appointment.PetSitterId;
            exist.DateTime = appointment.DateTime;
            exist.Status = appointment.Status;
            exist.Notes = appointment.Notes;
            exist.Price = existingSpapackage.SpaPackage.Price;

            _unitOfWork.AppointmentRepository.Update(exist);
            if (await _unitOfWork.AppointmentRepository.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                return "Service not found";
        }

        public async Task<string> DeleteAppoiment(int Id)
        {
            var exist = await _unitOfWork.AppointmentRepository.GetByIdAsync(Id, e => e.IsDeleted == false);
            if (exist == null)
                return "Service not found";

            _unitOfWork.AppointmentRepository.SoftRemove(exist);
            if (await _unitOfWork.AppointmentRepository.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                return "Service not found";
        }

        public async Task<bool> CancelAppoimentById(int Id)
        {
            try
            {
                var exist = await _unitOfWork.AppointmentRepository.GetByIdAsync(Id);
                if (exist == null)
                    throw new Exception("Non-existed appointment");

                // Kiểm tra xem còn lại bao nhiêu giờ trước khi đến giờ hẹn
                var hoursRemaining = (exist.DateTime - DateTime.UtcNow.AddHours(7)).TotalHours;

                if (hoursRemaining < 12)
                {
                    throw new Exception("Không thể hủy lịch hẹn trong vòng 12 tiếng trước giờ hẹn.");
                }
                _unitOfWork.AppointmentRepository.SoftRemove(exist);
                exist.Status = "CANCELLED";
                _unitOfWork.AppointmentRepository.Update(exist);

                if (await _unitOfWork.AppointmentRepository.SaveChangesAsync() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Appointment>> GetPetSitterAppointments(int id)
        {
            var list = await _unitOfWork.AppointmentRepository.GetAllAsync(a => a.IsDeleted == false && (a.PetSitterId == id || a.PetSitterId == null),
                                                                           a => a.User,
                                                                           a => a.SpaPackage,
                                                                           a => a.Pet);
            if (list == null)
                throw new Exception("Empty Appoiments");
            else
                return list;
        }

        public async Task<string> UpdateAppoimentStatus(Appointment appointment)
        {
            var exist = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointment.Id, e => e.IsDeleted == false);
            if (exist == null)
                return "Service not found";

            exist.PetSitterId = appointment.PetSitterId;
            exist.Status = appointment.Status;

            _unitOfWork.AppointmentRepository.Update(exist);
            if (await _unitOfWork.AppointmentRepository.SaveChangesAsync() > 0)
                return "Create Successfully";
            else
                return "Service not found";
        }

        public async Task<List<Appointment>> GetAppointmentsByUserId(int id)
        {
            var list = await _unitOfWork.AppointmentRepository.GetAllAsync(a => a.IsDeleted == false && a.UserId == id,
                                                                           a => a.User,
                                                                           a => a.SpaPackage,
                                                                           a => a.Pet);
            if (list == null)
                throw new Exception("Error");
            else
                return list;
        }

        public async Task<List<Appointment>> GetAllAppointmentAsync()
        {
            return await _unitOfWork.AppointmentRepository.GetAllAsync(null, x => x.User, x => x.SpaPackage, x => x.Pet);
        }

        public async Task<string> UpdateAppointmentStatusAsync(int appointmentId, string status)
        {
            var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointmentId);

            if (appointment == null)
            {
                throw new Exception("Appointment not found");
            }

            appointment.Status = status;

            _unitOfWork.AppointmentRepository.Update(appointment);

            if (await _unitOfWork.AppointmentRepository.SaveChangesAsync() > 0)
            {
                return "Status updated successfully";
            }
            else
            {
                throw new Exception("Error updating status");
            }
        }

        public async Task<List<Appointment>> GetAppointmentsByPetSitterId(int petSitterId)
        {
            var appointments = await _unitOfWork.AppointmentRepository.GetAllAsync(
                a => a.PetSitterId == petSitterId,
                a => a.User,
                a => a.SpaPackage,
                a => a.Pet);

            return appointments;
        }

        public async Task<List<Appointment>> GetAppointmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.AppointmentRepository.GetAllAsync(a => a.DateTime >= startDate && a.DateTime <= endDate);
        }

        public async Task<List<Payment>> GetPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.PaymentRepository.GetAllAsync(p => p.PaymentDate >= startDate && p.PaymentDate <= endDate);
        }

        public async Task<Pagination<Appointment>> GetAppointmentsFiltered(string search, PaginationParameter pagination)
        {
            return await GetAppointmentsFiltered(search, pagination);
        }
    }
}