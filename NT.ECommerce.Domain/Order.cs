using NT.ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Domain
{
    public class Order : BaseDomainEntity
    {
        public int Amount { get; set; }
        [Column(TypeName = "decimal (18,2)")]
        public decimal AppliedDiscount { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
