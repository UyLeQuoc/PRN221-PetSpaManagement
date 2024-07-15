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