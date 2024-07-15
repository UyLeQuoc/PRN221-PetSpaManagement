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
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IMapper mapper, IClaimsService claimsService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _claimsService = claimsService;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Appointment>> GetAppointments()
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

        //public async Task<string> CreateAppoiment(Appointment appointment)
        //{
        //    var exist = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointment.Id, e => e.IsDeleted == false);

        //    if (exist != null)
        //        return "Service exists";
        //    await _unitOfWork.AppointmentRepository.AddAsync(appointment);
        //    if (await _unitOfWork.AppointmentRepository.SaveChangesAsync() > 0)
        //        return "Create Successfully";
        //    else
        //        return "Create Failed";
        //}

        public async Task<Appointment> CreateNewAppointment(Appointment appointment)
        {
            try
            {
                var exist = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointment.Id, e => e.IsDeleted == false);
                if (exist != null)
                {
                    throw new Exception("existed appointment");
                }
                var existingSpapackage = await _unitOfWork.SpaPackageRepository.GetSpaPackageByID(appointment.SpaPackageId);
                if (existingSpapackage == null)
                {
                    throw new Exception("Non-existed spa package");
                }
                var existingPet = await _unitOfWork.PetRepository.GetByIdAsync(appointment.PetId);
                if (existingSpapackage == null)
                {
                    throw new Exception("Non-existed pet");
                }

                var newAppointment = new Appointment()
                {
                    UserId = appointment.UserId,
                    SpaPackageId = existingSpapackage.SpaPackage.Id,
                    PetId = existingPet.Id,
                    PetSitterId = appointment.PetSitterId,
                    DateTime = appointment.DateTime,
                    Status = appointment.Status,
                    Notes = appointment.Notes,
                    Price = existingSpapackage.SpaPackage.Price,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                };

                await _unitOfWork.AppointmentRepository.AddAsync(newAppointment);
                if (await _unitOfWork.SaveChangeAsync() > 0)
                {
                    return newAppointment;
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

            var existingSpapackage = await _unitOfWork.SpaPackageRepository.GetSpaPackageByID(appointment.SpaPackageId);
            if (existingSpapackage == null)
            {
                throw new Exception("Non-existed spa package");
            }

            exist.UserId = appointment.UserId;
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
    }
}