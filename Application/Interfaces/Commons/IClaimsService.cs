using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Commons
{
    public interface IClaimsService
    {
        int GetCurrentUserId { get; }
        string? IpAddress { get; }
    }
}