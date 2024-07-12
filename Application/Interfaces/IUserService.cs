using Domain.Entities;
using RepositoryLayer.Models;

namespace ServiceLayer.Interfaces
{
	public interface IUserService
	{
		Task<User> GetUserByEmailAsync(string email);
		Task<LoginResponse> LoginAsync(string email, string password);
		Task<User> RegisterAsync(User user);
	}
}
