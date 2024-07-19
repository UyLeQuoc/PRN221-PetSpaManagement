using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Commons;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        private readonly PetSpaManagementDbContext _context;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public AppointmentRepository(PetSpaManagementDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _context = context;
            _timeService = timeService;
            _claimsService = claimsService;
        }

        public async Task<Pagination<Appointment>> GetAppointmentsFiltered(string search, PaginationParameter pagination)
        {
            var query = _context.Appointments.Include(x => x.User).Include(x => x.Pet).Include(x => x.SpaPackage).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.UserId.ToString().Contains(search) || 
                                         p.PetId.ToString().Contains(search) ||
                                         p.SpaPackageId.ToString().Contains(search));  
            }   

            var list = query.Where(x => x.IsDeleted == false).OrderBy(x => x.CreatedAt);
            int count = list.Count();
            var Appointments = await list.Skip((pagination.PageIndex - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();
            var result = new Pagination<Appointment>(Appointments)
            {
                CurrentPage = pagination.PageIndex,
                PageSize = pagination.PageSize,
                TotalCount = count,
                PageIndex = pagination.PageIndex,
            };

            return result;
        }
    }
}