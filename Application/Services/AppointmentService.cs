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

        public async Task<Appointment> CreateNewAppointment()
        {
            return null;
        }
    }
}