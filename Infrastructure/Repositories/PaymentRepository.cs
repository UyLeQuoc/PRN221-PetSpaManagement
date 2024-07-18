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
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        private readonly PetSpaManagementDbContext _context;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;

        public PaymentRepository(PetSpaManagementDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base(context, timeService, claimsService)
        {
            _context = context;
            _timeService = timeService;
            _claimsService = claimsService;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync()
        {
            return await _context.Payments.OrderBy(x => x.CreatedAt).Include(x => x.Appointment).ThenInclude(x => x.SpaPackage).Include(x => x.User).ToListAsync();
        }
    }
}