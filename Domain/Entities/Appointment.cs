using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int UserId { get; set; }
        public int SpaPackageId { get; set; }
        public int PetId { get; set; }
        public int? PetSitterId { get; set; }
        public DateTime DateTime { get; set; }
        public string? Status { get; set; }
        public string? Notes { get; set; }
        public decimal? Price { get; set; }

        //navigation
        [ValidateNever]
        public virtual Pet Pet { get; set; }
        [ValidateNever]
        public virtual User User { get; set; }

        public virtual SpaPackage? SpaPackage { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
    }
}