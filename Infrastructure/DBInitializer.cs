using Domain.Entities;

namespace Infrastructure
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
		}
	}
}
