using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
	public interface IAppointmentService
	{
		Task<List<Appointment>> GetAppointments();
		Task<Appointment> GetAppointmentById(int id);
		Task<string> CreateAppoiment(Appointment appointment);
		Task<string> UpdateAppoiment(Appointment appointment);
		Task<string> DeleteAppoiment(Appointment appointment);
	}
}
