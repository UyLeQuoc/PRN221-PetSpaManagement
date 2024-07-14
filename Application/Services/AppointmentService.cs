using Domain.Entities;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
	public class AppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepository;

		public AppointmentService(IAppointmentRepository appointmentRepository)
		{
			_appointmentRepository = appointmentRepository;
		}

		public async Task<string> CreateAppoiment(Appointment appointment) 
			=> await _appointmentRepository.CreateAppoiment(appointment);

		public async Task<string> DeleteAppoiment(Appointment appointment) 
			=> await _appointmentRepository.DeleteAppoiment(appointment);

		public async Task<Appointment> GetAppointmentById(int id) 
			=> await _appointmentRepository.GetAppointmentById(id);

		public async Task<List<Appointment>> GetAppointments() 
			=> await _appointmentRepository.GetAppointments();

		public async Task<string> UpdateAppoiment(Appointment appointment) 
			=> await _appointmentRepository.UpdateAppoiment(appointment);

	}
}
