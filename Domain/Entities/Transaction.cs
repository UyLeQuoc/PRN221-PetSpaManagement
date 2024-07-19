using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public string? AccountNumber { get; set; } // banktrano
        public string? TransactionToken { get; set; } //token
        public decimal AmountOfMoney { get; set; } // amount
        public string? TransactionNo { get; set; } //transaction no
        public string? PaymentType { get; set; }
        public string? Status { get; set; } // 00 success

        public virtual Payment Payment { get; set; }
    }
}