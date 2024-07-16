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
                    new User {Name = "PetSitter1", Email="petsitter1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "PetSitter2", Email="petsitter2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "PetSitter3", Email="petsitter3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "PetSitter4", Email="petsitter4@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 3 },
                    new User {Name = "customer1", Email="customer1@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer2", Email="customer2@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer3", Email="customer3@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer4", Email="customer4@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                };

                foreach (var user in users)
                {
                    await context.Users.AddAsync(user);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Weight.Any())
            {
                var weights = new List<Weight>
                {
                    new Weight {FromWeight = 3, ToWeight = 4 },
                    new Weight {FromWeight = 5, ToWeight = 8 },
                    new Weight {FromWeight = 7, ToWeight = 10 },
                };

                foreach (var weight in weights)
                {
                    await context.Weight.AddAsync(weight);
                }
                await context.SaveChangesAsync();
            }

            if (!context.Services.Any())
            {
                var services = new List<Service>
                {
                    new Service {Name = "Tắm cho thú cưng", Description = "Tắm cho thú bằng nước ấm, với xà phòng trị ve rận và sấy khô, chải lông sau khi tắm ", WeightId = 1, Duration = 10},
                    new Service {Name = "Tắm cho thú cưng", Description = "Tắm cho thú bằng nước ấm, với xà phòng trị ve rận và sấy khô, chải lông sau khi tắm ", WeightId = 2, Duration = 15},
                    new Service {Name = "Tắm cho thú cưng", Description = "Tắm cho thú bằng nước ấm, với xà phòng trị ve rận và sấy khô, chải lông sau khi tắm ", WeightId = 3, Duration = 15},
                    new Service {Name = "Cắt móng cho thú cưng", Description = "Cắt và mài móng ", WeightId = 1, Duration = 10},
                    new Service {Name = "Cắt móng cho thú cưng", Description = "Cắt và mài móng", WeightId = 2, Duration = 15},
                    new Service {Name = "Cắt móng cho thú cưng", Description = "Cắt và mài móng ", WeightId = 3, Duration = 15},
                    new Service {Name = "Tỉa lông cho thú cưng", Description = "Tỉa lông thú gọn gàng, phù hợp với kích thước và giống thú cưng của bạn ", WeightId = 1, Duration = 20},
                    new Service {Name = "Tỉa lông cho thú cưng", Description = "Tỉa lông thú gọn gàng, phù hợp với kích thước và giống thú cưng của bạn", WeightId = 2, Duration = 20},
                    new Service {Name = "Tỉa lông cho thú cưng", Description = "Tỉa lông thú gọn gàng, phù hợp với kích thước và giống thú cưng của bạn ", WeightId = 3, Duration = 20},

                };

                foreach (var service in services)
                {
                    await context.Services.AddAsync(service);
                }
                await context.SaveChangesAsync();
            }

            if (!context.SpaPackages.Any())
            {
                var spaPackages = new List<SpaPackage>
                {
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 1", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 150000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/TRIEN-LAM-THU-CUNG-VIET-NAM.png", EstimatedTime = 40},
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 2", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 200000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/deciding-on-pet-care-pet-insurance.jpg.webp", EstimatedTime = 50},
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 3", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 250000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/spa-thu-cung-1.jpg.webp", EstimatedTime = 50},
                };

                foreach (var spaPackage in spaPackages)
                {
                    await context.SpaPackages.AddAsync(spaPackage);
                }
                await context.SaveChangesAsync();
            }

            if (!context.PackageServices.Any())
            {
                var packageServices = new List<PackageService>
                {
                    new PackageService{SpaPackageId = 1, ServiceId = 1},
                    new PackageService{SpaPackageId = 1, ServiceId = 4},
                    new PackageService{SpaPackageId = 1, ServiceId = 7},
                    new PackageService{SpaPackageId = 2, ServiceId = 2},
                    new PackageService{SpaPackageId = 2, ServiceId = 5},
                    new PackageService{SpaPackageId = 2, ServiceId = 8},
                    new PackageService{SpaPackageId = 3, ServiceId = 3},
                    new PackageService{SpaPackageId = 3, ServiceId = 6},
                    new PackageService{SpaPackageId = 3, ServiceId = 9},
                };

                foreach (var packageService in packageServices)
                {
                    await context.PackageServices.AddAsync(packageService);
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
        }
    }
}
