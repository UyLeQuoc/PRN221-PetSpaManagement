using Domain.Entities;
using RepositoryLayer.Utils;

namespace RepositoryLayer
{
    public static class DBInitializer
    {
        public static async Task Initialize(PetSpaManagementDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin"},
                    new Role { Name = "Manager" },
                    new Role { Name = "PetSitter" },
                    new Role { Name = "Customer" }
                };

                foreach (var role in roles)
                {
                    await context.Roles.AddAsync(role);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User {Name = "admin", Email="admin@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 1 },
                    new User {Name = "manager", Email="manager@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 2 },
                    new User {Name = "petsitter", Email="petsitter@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "customer", Email="customer@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 }
                };

                foreach (var user in users)
                {
                    await context.Users.AddAsync(user);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
