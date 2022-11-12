using NT.ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Domain
{
    public class OrderProducts : BaseDomainEntity
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }   
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
