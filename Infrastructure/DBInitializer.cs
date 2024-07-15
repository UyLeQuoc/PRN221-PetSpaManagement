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
                    new User {Name = "customer", Email="customer@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "PetSitter1", Email="petsitter@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "PetSitter2", Email="petsitter@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "PetSitter3", Email="petsitter@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "PetSitter4", Email="petsitter@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "customer1", Email="customer@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer2", Email="customer@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer3", Email="customer@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer4", Email="customer@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                };

                foreach (var user in users)
                {
                    await context.Users.AddAsync(user);
                }
                await context.SaveChangesAsync();
            }

            if (!context.SpaPackages.Any())
            {
                var spaPackages = new List<SpaPackage>
                {
                    new SpaPackage {Name = "Package1", Description="a", Price = 100},
                    new SpaPackage {Name = "Package2", Description="a", Price = 100},
                    new SpaPackage {Name = "Package3", Description="a", Price = 100},
                    new SpaPackage {Name = "Package4", Description="a", Price = 100}
                };

                foreach (var package in spaPackages)
                {
                    await context.SpaPackages.AddAsync(package);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Pets.Any())
            {
                var pets = new List<Pet>
                {
                    new Pet {Name = "BullDog", Description="a", Type = "Dog"},
                    new Pet {Name = "Calico", Description="a", Type = "Cat"},
                    new Pet {Name = "Shiba", Description="a", Type = "Dog"},
                    new Pet {Name = "Corgi", Description="a", Type = "Dog"},
                    new Pet {Name = "Ginger", Description="a", Type = "Cat"},
                    new Pet {Name = "husky", Description="a", Type = "Dog"},
                    new Pet {Name = "Pug", Description="a", Type = "Dog"}
                };

                foreach (var pet in pets)
                {
                    await context.Pets.AddAsync(pet);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Appointments.Any())
            {
                var appointments = new List<Appointment>
                {
                    new Appointment {UserId = 9, SpaPackageId = 1, PetId = 1, PetSitterId = 5, DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, CreatedBy = 1, Price = 20},
                    new Appointment {UserId = 10, SpaPackageId = 2, PetId = 2, PetSitterId = 6, DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, CreatedBy = 1, Price = 20},
                };

                foreach (var pet in appointments)
                {
                    await context.Appointments.AddAsync(pet);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
