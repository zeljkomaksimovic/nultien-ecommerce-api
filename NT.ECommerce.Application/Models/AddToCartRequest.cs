using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Models
{
    public class AddToCartRequest
    {
        public int CustomerId { get; set; } 
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
