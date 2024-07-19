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

            if (!context.SpaPackages.Any())
            {
                var spaPackages = new List<SpaPackage>
                {
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 1", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 150000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/TRIEN-LAM-THU-CUNG-VIET-NAM.png", EstimatedTime = 40},
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 2", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 200000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/deciding-on-pet-care-pet-insurance.jpg.webp", EstimatedTime = 50},
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 3", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 250000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/spa-thu-cung-1.jpg.webp", EstimatedTime = 50},
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 1", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 150000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/TRIEN-LAM-THU-CUNG-VIET-NAM.png", EstimatedTime = 30},
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 2", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 200000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/deciding-on-pet-care-pet-insurance.jpg.webp", EstimatedTime = 20 },
                    new SpaPackage {Name = "Combo chăm sóc cho thú cưng 3", Description = "Bao gồm tắm, cắt móng và tỉa lông", Price = 250000, PictureUrl="https://image-petspamanagement.s3.ap-southeast-2.amazonaws.com/spa-thu-cung-1.jpg.webp", EstimatedTime = 10 }
                };

                foreach (var spaPackage in spaPackages)
                {
                    await context.SpaPackages.AddAsync(spaPackage);
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
                    new User {Name = "customer5", Email="customer5@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer6", Email="customer6@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer7", Email="customer7@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer8", Email="customer8@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer9", Email="customer9@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer10", Email="customer10@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer11", Email="customer11@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                    new User {Name = "customer12", Email="customer12@gmail.com", Password = PasswordTools.HashPassword("123456"), RoleId = 4 },
                };

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();

                if (!context.Pets.Any())
                {
                    var pets = new List<Pet>
                    {
                        new Pet {Name = "BullDog", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer") },
                        new Pet {Name = "Calico", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer1") },
                        new Pet {Name = "Shiba", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer2") },
                        new Pet {Name = "Corgi", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer3") },
                        new Pet {Name = "Ginger", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer4") },
                        new Pet {Name = "Husky", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer5") },
                        new Pet {Name = "Labrador Retriever", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer6") },
                        new Pet {Name = "Poodle", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer7") },
                        new Pet {Name = "Boxer", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer8") },
                        new Pet {Name = "Bengal", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer9") },
                        new Pet {Name = "Sphynx", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer10") },
                        new Pet {Name = "Persian", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer11") },
                        new Pet {Name = "Siamese", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer12") },
                        new Pet {Name = "British Shorthair", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer") },
                        new Pet {Name = "Ragdoll", Description="a", Type = "Cat", User = users.First(u => u.Name == "customer1") },
                        new Pet {Name = "Rottweiler", Description="a", Type = "Dog", User = users.First(u => u.Name == "customer2") }
                    };

                    await context.Pets.AddRangeAsync(pets);
                    await context.SaveChangesAsync();

                    if (!context.Appointments.Any())
                    {
                        var appointments = new List<Appointment>
                        {
                            new Appointment {User = users.First(u => u.Name == "customer1"), SpaPackageId = 1, Pet = pets.First(u => u.Name == "Calico"), DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer2"), SpaPackageId = 2, Pet = pets.First(u => u.Name == "Shiba"),  DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer3"), SpaPackageId = 3, Pet = pets.First(u => u.Name == "Corgi"), PetSitterId = 7, DateTime = DateTime.Now, Status = "ASSIGNED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer4"), SpaPackageId = 1, Pet = pets.First(u => u.Name == "Ginger"), PetSitterId = 8, DateTime = DateTime.Now, Status = "ASSIGNED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer"), SpaPackageId = 1, Pet = pets.First(u => u.Name == "BullDog"),  DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer"), SpaPackageId = 2, Pet = pets.First(u => u.Name == "British Shorthair"),  PetSitterId = 3, DateTime = DateTime.Now, Status = "ASSIGNED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer"), SpaPackageId = 3, Pet = pets.First(u => u.Name == "BullDog"),  PetSitterId = 3, DateTime = DateTime.Now, Status = "COMPLETED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer"), SpaPackageId = 1, Pet = pets.First(u => u.Name == "British Shorthair"),  PetSitterId = 3, DateTime = DateTime.Now, Status = "CANCELLED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                            new Appointment {User = users.First(u => u.Name == "customer"), SpaPackageId = 2, Pet = pets.First(u => u.Name == "BullDog"),  PetSitterId = 3, DateTime = DateTime.Now, Status = "ABSENT", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
                        };

                        await context.Appointments.AddRangeAsync(appointments);
                    }

                    await context.SaveChangesAsync();
                }
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

            if (!context.Pets.Any())
            {
                var pets = new List<Pet>
                {
                    new Pet {Name = "BullDog", Description="a", Type = "Dog" , UserId = 1 },
                    new Pet {Name = "Calico", Description="a", Type = "Cat"},
                    new Pet {Name = "Shiba", Description="a", Type = "Dog" , UserId = 1},
                    new Pet {Name = "Corgi", Description="a", Type = "Dog" , UserId = 1},
                    new Pet {Name = "Ginger", Description="a", Type = "Cat"},
                    new Pet {Name = "husky", Description="a", Type = "Dog" , UserId = 1},
                    new Pet {Name = "Labrador Retriever", Description="a", Type = "Dog" , UserId = 1},
                    new Pet {Name = "Poodle", Description="a", Type = "Dog" , UserId = 1},
                    new Pet {Name = "Boxer", Description="a", Type = "Dog" , UserId = 1},
                    new Pet {Name = "Bengal", Description="a", Type = "Cat"},
                    new Pet {Name = "Sphynx", Description="a", Type = "Cat"},
                    new Pet {Name = "Persian", Description="a", Type = "Cat"},
                    new Pet {Name = "Siamese", Description="a", Type = "Cat"},
                    new Pet {Name = "British Shorthair", Description="a", Type = "Cat"},
                    new Pet {Name = "Ragdoll", Description="a", Type = "Cat"},
                    new Pet {Name = "Rottweiler", Description="a", Type = "Dog" , UserId = 1}
                };

                foreach (var pet in pets)
                {
                    await context.Pets.AddAsync(pet);
                }
                await context.SaveChangesAsync();
            }

            //if (!context.Appointments.Any())
            //{
            //    var appointments = new List<Appointment>
            //    {
            //        new Appointment {UserId = 9, SpaPackageId = 1, PetId = 1, DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 10, SpaPackageId = 2, PetId = 2,  DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, Price = 100},

            //        new Appointment {UserId = 11, SpaPackageId = 3, PetId = 3, PetSitterId = 7, DateTime = DateTime.Now, Status = "ASSIGNED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 12, SpaPackageId = 1, PetId = 4, PetSitterId = 8, DateTime = DateTime.Now, Status = "ASSIGNED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 4, SpaPackageId = 2, PetId = 2,  DateTime = DateTime.Now, Status = "PENDING", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 4, SpaPackageId = 2, PetId = 2,  PetSitterId = 3, DateTime = DateTime.Now, Status = "ASSIGNED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 4, SpaPackageId = 2, PetId = 2,  PetSitterId = 3, DateTime = DateTime.Now, Status = "COMPLETED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 4, SpaPackageId = 2, PetId = 2,  PetSitterId = 3, DateTime = DateTime.Now, Status = "CANCELLED", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //        new Appointment {UserId = 4, SpaPackageId = 2, PetId = 2,  PetSitterId = 3, DateTime = DateTime.Now, Status = "ABSENT", Notes = "a", CreatedAt = DateTime.Now, Price = 100},
            //    };

            //    foreach (var pet in appointments)
            //    {
            //        await context.Appointments.AddAsync(pet);
            //    }
            //    await context.SaveChangesAsync();
            //}
        }
    }
}