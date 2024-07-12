using Domain.Entities;

namespace RepositoryLayer.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task<User> GetUserByEmailAsync(string email);
		Task<User> LoginAsync(string email, string password);
		Task<User> RegisterAsync(User user);
	}
}