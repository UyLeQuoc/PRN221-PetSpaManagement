using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PackageService : BaseEntity
    {
        public int? SpaPackageId { get; set; }
        public int? ServiceId { get; set; }

        //navigation

        public virtual SpaPackage? SpaPackage { get; set; }
        public virtual Service? Service { get; set; }
    }
}
