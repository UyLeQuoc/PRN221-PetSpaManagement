using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }

        //navigation
        public virtual Appointment Appointment { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Transaction>? Transactions { get; set; }
    }
}