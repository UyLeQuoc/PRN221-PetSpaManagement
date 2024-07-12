using Domain.Entities;
using RepositoryLayer.Commons;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		private readonly PetSpaManagementDbContext _context;
		private readonly ICurrentTime _timeService;
		private readonly IClaimsService _claimsService;

		public UserRepository(PetSpaManagementDbContext context, ICurrentTime currentTime, IClaimsService claimsService) : base(context, currentTime, claimsService)
		{
			_context = context;
			_timeService = currentTime;
			_claimsService = claimsService;
		}

		public Task<User> GetUserByEmailAsync(string email)
		{
			throw new NotImplementedException();
		}

		public Task<User> LoginAsync(string email, string password)
		{
			throw new NotImplementedException();
		}

		public Task<User> RegisterAsync(User user)
		{
			throw new NotImplementedException();
		}
	}
}
