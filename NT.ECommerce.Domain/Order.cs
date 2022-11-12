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
        public decimal? Amount { get; set; }
        public decimal? AppliedDiscount { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<OrderProducts>? OrderProducts { get; set; } = new();
    }
}
