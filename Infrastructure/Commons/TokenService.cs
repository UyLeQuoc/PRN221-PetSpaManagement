namespace RepositoryLayer.Commons
{
	using Domain.Entities;
	using Microsoft.Extensions.Configuration;
	using Microsoft.IdentityModel.Tokens;
	using System;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

	namespace ServiceLayer.Services
	{
		public interface ITokenService
		{
			string GenerateToken(User user);
		}

		public class TokenService : ITokenService
		{
			private readonly IConfiguration _configuration;

			public TokenService(IConfiguration configuration)
			{
				_configuration = configuration;
			}

			public string GenerateToken(User user)
			{
				var claims = new[]
				{
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

				var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:SecretKey"]));
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

				var token = new JwtSecurityToken(
					_configuration["JWTSettings:Issuer"],
					_configuration["JWTSettings:Audience"],
					claims,
					expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JWTSettings:TokenValidityInMinutes"])),
					signingCredentials: creds);

				return new JwtSecurityTokenHandler().WriteToken(token);
			}
		}
	}
}
