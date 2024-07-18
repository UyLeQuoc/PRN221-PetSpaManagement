using Domain.Entities;
using RepositoryLayer.Commons;

namespace RepositoryLayer.Interfaces
{
    public interface IAppointmentRepository : IGenericRepository<Appointment>
    {
        Task<Pagination<Appointment>> GetAppointmentsFiltered(string search, PaginationParameter pagination);
    }
}