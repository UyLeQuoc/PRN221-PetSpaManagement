using Domain.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
	public class AppointmentRepository : IAppointmentRepository
	{
		private readonly PetSpaManagementDbContext _context;
		private readonly IGenericRepository<Appointment> _genericRepository;

		public AppointmentRepository(
			PetSpaManagementDbContext context, 
			IGenericRepository<Appointment> genericRepository)
		{
			_context = context;
			_genericRepository = genericRepository;
		}

		public async Task<List<Appointment>> GetAppointments()
		{
			var list = await _genericRepository.GetAllAsync(a => a.IsDeleted == false,
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
			var appointment = await _genericRepository.GetByIdAsync(id);

			if (appointment == null) 
				throw new Exception("No Appointment found");
			else 
				return appointment;
		}

		public async Task<string> CreateAppoiment(Appointment appointment)
		{
			var exist = await _genericRepository.GetByIdAsync(appointment.Id, e => e.IsDeleted == false);

			if (exist != null)
				return "Service exists";
			await _genericRepository.AddAsync(appointment);
			if (await _genericRepository.SaveChangesAsync() > 0)
				return "Create Successfully";
			else
				return "Create Failed";
		}

		public async Task<string> UpdateAppoiment(Appointment appointment)
		{
			var exist = await _genericRepository.GetByIdAsync(appointment.Id, e => e.IsDeleted == false);
			if (exist == null)
				return "Service not found";

			exist.UserId = appointment.UserId;
			exist.SpaPackageId = appointment.SpaPackageId;
			exist.PetId = appointment.PetId;
			exist.PetSitterId = appointment.PetSitterId;
			exist.DateTime = appointment.DateTime;
			exist.Status = appointment.Status;
			exist.Notes = appointment.Notes;
			exist.Price = appointment.Price;

			_genericRepository.Update(exist);
			if (await _genericRepository.SaveChangesAsync() > 0)
				return "Create Successfully";
			else
				return "Service not found";
		}

		public async Task<string> DeleteAppoiment(int Id)
		{
			var exist = await _genericRepository.GetByIdAsync(Id, e => e.IsDeleted == false);
			if (exist == null)
				return "Service not found";

			_genericRepository.SoftRemove(exist);
			if (await _genericRepository.SaveChangesAsync() > 0)
				return "Create Successfully";
			else
				return "Service not found";
		}


	}
}
