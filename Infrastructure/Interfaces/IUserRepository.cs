using Domain.Entities;
using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> CurrentUserAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<LoginResponse> LoginAsync(string email, string password);
        Task<User> RegisterAsync(User user);
    }
}