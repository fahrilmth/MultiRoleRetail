using System;
using System.Collections.Generic;

namespace MultiRoleRetail.Models
{
    public partial class TransactionProduct
    {
        public string TransactionId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public int Quantity { get; set; }
        public int Price { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Transaction Transaction { get; set; } = null!;
    }
}
