using NT.ECommerce.Application.DTOs.Common;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.ShoppingCart
{
    public class ShoppingCartDto : BaseDto, IShoppingCartDto
    {
        public int CustomerId { get; set; }
        public CustomerDto? Customer { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }

        public int Quantity { get; set; }
    }
}
