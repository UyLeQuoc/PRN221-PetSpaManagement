using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using RepositoryLayer.Commons;
using RepositoryLayer.Commons.ServiceLayer.Services;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
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

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICurrentTime, CurrentTime>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//user
builder.Services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//pet-service
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
//spa-package
builder.Services.AddScoped<ISpaPackageService, SpaPackageService>();
builder.Services.AddScoped<ISpaPackageRepository, SpaPackageRepository>();



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
