using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Duration { get; set; }
        public string? PictureUrl { get; set; }

        //navigation
        public virtual ICollection<PackageService>? PackageServices { get; set; } = new List<PackageService>();
        public virtual Weight Weight { get; set; }
    }
}