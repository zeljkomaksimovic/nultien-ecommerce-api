using NT.ECommerce.Application.DTOs.Common;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Product
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public ProductStorageType StorageType { get; set; }
    }
}
