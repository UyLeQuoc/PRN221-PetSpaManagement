﻿using Application.Interfaces;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
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