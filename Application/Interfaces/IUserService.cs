using Domain.Entities;
using RepositoryLayer.Models;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(User entity);
        Task<bool> UpdateAsync(User entity);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<User> GetCurrentUserAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<LoginResponse> LoginAsync(string email, string password);
        Task<User> RegisterAsync(User user);
        Task<List<User>> GetUsersByRoleIdAsync(int roleId);
        Task<UserResponse> GetUsersByRoleIdAsync(int roleId, string searchTerm, int pageIndex, int pageSize);
        Task<Dictionary<string, int>> GetUserCountsByRoleAsync();
    }
}
