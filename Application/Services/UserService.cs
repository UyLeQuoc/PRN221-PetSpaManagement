using Domain.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _userRepository.GetUserByEmailAsync(email);
        }

        public Task<LoginResponse> LoginAsync(string email, string password)
        {
            return _userRepository.LoginAsync(email, password);
        }

        public Task<User> RegisterAsync(User user)
        {
            return _userRepository.RegisterAsync(user);
        }

        public Task<User> GetCurrentUserAsync()
        {
            return _userRepository.CurrentUserAsync();
        }
    }
}