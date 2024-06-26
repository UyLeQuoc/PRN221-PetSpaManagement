﻿using Application.Interfaces.Commons;
using Application.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons
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
        }

        public int GetCurrentUserId { get; }

        public string? IpAddress { get; }
    }
}