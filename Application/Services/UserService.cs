using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class UserService : IUserService
	{
		public async Task<string> Meomaybe()
		{
			//await async bloblalal
			return "Mẹ mày béo";
		}
	}
}
