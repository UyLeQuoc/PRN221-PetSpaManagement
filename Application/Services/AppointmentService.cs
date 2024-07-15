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

        public async Task<Appointment> CreateNewAppointment(Appointment appointment)
        {
            try
            {
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
                    Price = appointment.SpaPackage.Price
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
    }
}