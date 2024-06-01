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
        public virtual ICollection<Pet>? Pets { get; set; } = new List<Pet>();
        public virtual ICollection<Review>? Reviews { get; set; } = new List<Review>();
        //public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
        //public virtual ICollection<Appointment>? StaffAppointments { get; set; } = new List<Appointment>();





    }
}
