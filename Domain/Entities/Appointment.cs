using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment:BaseEntity
    {
        public int UserId { get; set; }
        public int SpaPackageId { get; set; }
        public int PetId {  get; set; }
        public int? StaffId { get; set; }
        public DateTime DateTime { get; set; }
        public string Status {  get; set; }
        public string Notes {  get; set; }

        //navigation

        //public virtual User? User { get; set; }
        //public virtual User? Staff { get; set; }
        public virtual Pet? Pet { get; set; }
        public virtual SpaPackage? SpaPackage { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();




    }
}
