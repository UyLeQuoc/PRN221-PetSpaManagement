using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Models
{
    public class SpaPackageDetailResponse 
    {
        public SpaPackage SpaPackage { get; set; }
        public List<Service> Services { get; set; }

    }

}
