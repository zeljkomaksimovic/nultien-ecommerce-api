using NT.ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Domain
{
    public class Product : BaseDomainEntity
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal (18,2)")]
        public decimal? UnitPrice { get; set; }
    }
}
