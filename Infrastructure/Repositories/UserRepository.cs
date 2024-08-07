﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Commons;
using RepositoryLayer.Commons.ServiceLayer.Services;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Utils;

namespace RepositoryLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PetSpaManagementDbContext _context;
        private readonly ICurrentTime _timeService;
        private readonly IClaimsService _claimsService;
        private readonly ITokenService _tokenService;

        public UserRepository(
            PetSpaManagementDbContext context,
            ICurrentTime currentTime,
            IClaimsService claimsService,
            ITokenService tokenService) : base(context, currentTime, claimsService)
        {
            _context = context;
            _timeService = currentTime;
            _claimsService = claimsService;
            _tokenService = tokenService;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("This email is not exist");
            }
            var isCorrectPassword = PasswordTools.VerifyPassword(password, user.Password);
            if (!isCorrectPassword)
            {
                throw new UnauthorizedAccessException("Incorrect password");
            }
            //if user is not active
            if (user.IsDeleted == true)
            {
                throw new UnauthorizedAccessException("You are banned!");
            }

            return new LoginResponse
            {
                User = user,
                Token = _tokenService.GenerateToken(user)
            };
        }

        public async Task<User> RegisterAsync(User user)
        {
            var existingUser = await _context.Users.AnyAsync(u => u.Email == user.Email);
            if (existingUser)
            {
                throw new ArgumentException("Email already exists");
            }

            //Hash password
            user.Password = PasswordTools.HashPassword(user.Password);
            user.RoleId = 4; //Default role is Customer

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> CurrentUserAsync()
        {
            try
            {
                var userId = _claimsService.GetCurrentUserId;
                var currentUser = await _context.Users.FindAsync(userId);
                if (currentUser == null)
                {
                    throw new Exception("There is no user signed in");
                }
                return currentUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<User>> GetUsersByRoleIdAsync(int roleId)
        {
            return await _context.Users.Where(u => u.RoleId == roleId).ToListAsync();
        }

        public async Task<UserResponse> GetUsersByRoleIdAsync(int roleId, string searchTerm, int pageIndex, int pageSize)
        {
            var query = _context.Users.Where(u => u.RoleId == roleId).AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(u => u.Name.Contains(searchTerm) || u.Email.Contains(searchTerm));
            }
            int count = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(count / (double)pageSize);

            query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            return new UserResponse
            {
                Users = await query.ToListAsync(),
                TotalPages = totalPages,
                PageIndex = pageIndex
            };
        }

        public async Task<Dictionary<string, int>> GetUserCountsByRoleAsync()
        {
            return await _context.Users
                .GroupBy(u => u.Role.Name)
                .Select(g => new { RoleName = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.RoleName, x => x.Count);
        }
    }
}