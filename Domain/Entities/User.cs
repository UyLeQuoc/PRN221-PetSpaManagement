using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        //navigation
        public virtual Role? Role { get; set; }

        public virtual ICollection<Pet>? Pets { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}