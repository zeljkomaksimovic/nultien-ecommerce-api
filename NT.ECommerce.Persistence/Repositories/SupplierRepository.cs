using NT.ECommerce.Application.Contracts;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Persistence.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public ProductDto GetSupplierStocksOfProduct(int id, int quantity)
        {
            var productList = new List<ProductDto>()
            {
                  new ProductDto
                  {
                             Id = 1,
                             Name = "Hoodie",
                             Quantity = 4,
                             UnitPrice = 2490.90m,
                             StorageType = ProductStorageType.Supplier
                  },
                  new ProductDto
                  {
                            Id = 2,
                            Name = "T-Shirt",
                            Quantity = 2,
                            UnitPrice = 1390.90m,
                            StorageType = ProductStorageType.Supplier
                  }
            };

            return productList.Where(x => x.Id == id && x.Quantity >= quantity).FirstOrDefault()!;
        }
    }
}
