using Application.Interfaces.IServices;
using Application.Repositories;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetSpaManagementDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();



var app = builder.Build();

// SCOPE FOR MIGRATION
// explain: The CreateScope method creates a new scope. The scope is a way to manage the lifetime of objects in the container.
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<PetSpaManagementDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
	await DBInitializer.Initialize(context);
}
catch (Exception ex)
{
	logger.LogError(ex, "An problem occurred during migration!");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
