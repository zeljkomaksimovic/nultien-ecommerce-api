using AutoMapper;
using Moq;
using NT.ECommerce.Application.Contracts;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Enums;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Mocks
{
    public class MockSupplierRepository
    {
        public static Mock<ISupplierRepository> GetSupplierRepository()
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

            var mockRepository = new Mock<ISupplierRepository>();

            mockRepository.Setup(q => q.GetSupplierStocksOfProduct(It.IsAny<int>(), It.IsAny<int>())).Returns((int id, int quantity) =>
            {
                return productList.Where(x => x.Id == id && x.Quantity >= quantity).FirstOrDefault()!;
            });

            return mockRepository;
        }
    }
}
