using Domain.Entities;
using RepositoryLayer;
using RepositoryLayer.Models;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _unitOfWork.UserRepository.GetUserByEmailAsync(email);
        }

        public Task<LoginResponse> LoginAsync(string email, string password)
        {
            return _unitOfWork.UserRepository.LoginAsync(email, password);
        }

        public Task<User> RegisterAsync(User user)
        {
            return _unitOfWork.UserRepository.RegisterAsync(user);
        }

        public Task<User> GetCurrentUserAsync()
        {
            return _unitOfWork.UserRepository.CurrentUserAsync();
        }
        public async Task<List<User>> GetUsersByRoleIdAsync(int roleId)
        {
            return await _unitOfWork.UserRepository.GetUsersByRoleIdAsync(roleId);
        }

        public async Task<bool> AddAsync(User entity)
        {
            await _unitOfWork.UserRepository.AddAsync(entity);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateAsync(User entity)
        {
            _unitOfWork.UserRepository.Update(entity);
            return await _unitOfWork.SaveChangeAsync() > 0;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.UserRepository.SoftRemove(id);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _unitOfWork.UserRepository.GetByIdAsync(id);
        }
    }
}