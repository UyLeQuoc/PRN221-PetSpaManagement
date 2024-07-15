using Domain.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories;
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

        public async Task<List<User>> GetCustomer()
        {
            var list = await _userRepository.GetAllAsync(a => a.IsDeleted == false && a.RoleId == 4);

            if (list == null)
                throw new Exception("Empty Customer");
            else
                return list;
        }

        public async Task<List<User>> GetPetSitter()
        {
            var list = await _userRepository.GetAllAsync(a => a.IsDeleted == false && a.RoleId == 3);

            if (list == null)
                throw new Exception("Empty Petsitter");
            else
                return list;
        }
    }
}
