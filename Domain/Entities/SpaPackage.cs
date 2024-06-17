using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SpaPackage : BaseEntity
    {
        public string Name {  get; set; }
        public string? Description { get; set; }

        public decimal? Price { get; set; }
        public string? PictureUrl {  get; set; }
        public int? EstimatedTime {  get; set; }
        //navigation

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<PackageService>? PackageServices { get; set; } = new List<PackageService>();

    }
}
