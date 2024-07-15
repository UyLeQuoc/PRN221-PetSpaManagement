using Domain.Entities;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
	public interface IAppointmentRepository
	{
		Task<List<Appointment>> GetAppointments();
		Task<Appointment> GetAppointmentById(int id);
		Task<string> CreateAppoiment(Appointment appointment);
		Task<string> UpdateAppoiment(Appointment appointment);
		Task<string> DeleteAppoiment(int id);
	}
}
