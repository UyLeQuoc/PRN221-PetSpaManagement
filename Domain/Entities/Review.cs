using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review : BaseEntity
    {
        public int? UserId { get; set; }
        public int? AppointmentId { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public string? PictureUrl { get; set; }

        //navigation
        public virtual User? User { get; set; }

        public virtual Appointment? Appointment { get; set; }
    }
}