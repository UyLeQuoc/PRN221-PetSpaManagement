using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PetSpaManagementDbContext : DbContext
    {
        public PetSpaManagementDbContext(DbContextOptions<PetSpaManagementDbContext> options) : base(options)
        {


        }
    }
}
