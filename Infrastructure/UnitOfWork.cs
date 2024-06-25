using Application;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PetSpaManagementDbContext _context;

        public UnitOfWork(PetSpaManagementDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
