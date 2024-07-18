using Amazon.S3;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetSpaManagementWeb.Pages.ManagerDashboard.Services;
using RepositoryLayer;
using RepositoryLayer.Commons;
using RepositoryLayer.Commons.ServiceLayer.Services;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using ServiceLayer.Interfaces;
using ServiceLayer.Mappers;
using ServiceLayer.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAutoMapper(typeof(MapperConfigProfile).Assembly);
builder.Services.AddScoped<ILogger<EditModel>, Logger<EditModel>>();
builder.Services.AddDefaultAWSOptions(configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();

builder.Services.AddDbContext<PetSpaManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(builder.Configuration["JWTSettings:SecretKey"]))
        };
    });

builder.Services.AddSession();
builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor();
//infrastructure
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICurrentTime, CurrentTime>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IStorageService, S3StorageService>();

//user
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//pet-service
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
//spa-package
builder.Services.AddScoped<ISpaPackageRepository, SpaPackageRepository>();
//weight
builder.Services.AddScoped<IWeightRepository, WeightRepository>();
//pet
builder.Services.AddScoped<IGenericRepository<Pet>, GenericRepository<Pet>>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
//appointment
builder.Services.AddScoped<IGenericRepository<Appointment>, GenericRepository<Appointment>>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

//payment
builder.Services.AddScoped<IGenericRepository<Payment>, GenericRepository<Payment>>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

//UOW
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Services
builder.Services.AddScoped<IStorageService, S3StorageService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IWeightService, WeightService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<ISpaPackageService, SpaPackageService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

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

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();