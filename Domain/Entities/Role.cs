﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<User>? Users { get; set; } = new List<User>();

    }
}
