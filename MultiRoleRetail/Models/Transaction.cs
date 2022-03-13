using System;
using System.Collections.Generic;

namespace MultiRoleRetail.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionProducts = new HashSet<TransactionProduct>();
        }

        public string ColId { get; set; } = null!;
        public DateTime Date { get; set; }
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
