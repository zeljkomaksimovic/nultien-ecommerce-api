using NT.ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Domain
{
    public class ShoppingCart : BaseDomainEntity
    {
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
