using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public string? PictureUrl { get; set; }

        public string? Type { get; set; }

        public int? UserId { get; set; }

        //NAVIGATION
        public virtual User? User { get; set; }
    }
}