using Domain.Entities;

namespace RepositoryLayer.Models
{
	public class LoginResponse
	{
		public string Token { get; set; }
		public User User { get; set; }
	}

}
