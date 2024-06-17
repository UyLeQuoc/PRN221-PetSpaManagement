using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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
