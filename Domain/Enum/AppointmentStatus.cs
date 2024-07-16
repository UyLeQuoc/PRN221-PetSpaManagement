using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum AppointmentStatus
    {
        PENDING = 1,
        ASSIGNED = 2,
        COMPLETED = 3,
        CANCELLED = 4,
        ABSENT = 5
        //not yet apllied, intented for future cooking
    }
}
