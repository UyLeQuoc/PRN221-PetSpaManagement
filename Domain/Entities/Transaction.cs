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
        public string? AccountNumber { get; set; }
        public string? TransactionToken { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string? TransactionNo { get; set; }
        public string? PaymentType { get; set; }
        public string? Status { get; set; }

        public virtual Payment Payment { get; set; }
    }
}