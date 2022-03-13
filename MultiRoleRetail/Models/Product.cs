using System;
using System.Collections.Generic;

namespace MultiRoleRetail.Models
{
    public partial class Product
    {
        public Product()
        {
            TransactionProducts = new HashSet<TransactionProduct>();
        }

        public string ColId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Stock { get; set; }
        public string SupplierId { get; set; } = null!;

        public virtual Supplier Supplier { get; set; } = null!;
        public virtual ICollection<TransactionProduct> TransactionProducts { get; set; }
    }
}
