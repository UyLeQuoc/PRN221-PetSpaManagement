using Microsoft.AspNetCore.Http;
using RepositoryLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Commons
{
    public class ClaimsService : IClaimsService
    {
        public ClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            // todo implementation to get the current userId
            var identity = httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            var extractedId = AuthenTools.GetCurrentUserId(identity);
            GetCurrentUserId = string.IsNullOrEmpty(extractedId) ? -1 : int.Parse(extractedId);
            IpAddress = httpContextAccessor?.HttpContext?.Connection?.LocalIpAddress?.ToString();

            var userId = httpContextAccessor.HttpContext?.Session.GetInt32("UserId") ?? 0;
            var email = httpContextAccessor.HttpContext.Session.GetString("Email");

            if (email == null)
            {
                GetCurrentSessionUserId = -1;
            }
            else
            {
                GetCurrentSessionUserId = userId;
            }
            GetCurrentUserIdEmail = email;
        }

        public int GetCurrentUserId { get; }
        public string GetCurrentUserIdEmail { get; } = string.Empty;
        public int GetCurrentSessionUserId { get; }

        public string? IpAddress { get; }
    }
}