using System.Security.Claims;

namespace RepositoryLayer.Utils
{
	public static class AuthenTools
	{
		public static string GetCurrentUserId(ClaimsIdentity identity)
		{
			if (identity != null)
			{
				var userClaims = identity.Claims;
				return userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value; // THAY VÌ .Name thì đặt tên gì cũng dc cưng
			}
			return null;
		}
	}
}