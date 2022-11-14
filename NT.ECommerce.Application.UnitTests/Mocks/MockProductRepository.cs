using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Mocks
{
    public class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                         {
                             Id = 1,
                             Name = "Hoodie",
                             Quantity = 0,
                             UnitPrice = 2490.90m,
                             StorageType = 1,
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                        new Product
                        {
                            Id = 2,
                            Name = "T-Shirt",
                            Quantity = 2,
                            UnitPrice = 1390.90m,
                            StorageType= 1,
                            CreatedBy = "zmaksimovic",
                            DateCreated = DateTime.Now,
                            Status = true
                        }
            };

            var mockRepository = new Mock<IProductRepository>();

            mockRepository.Setup(q => q.GetAllAsync()).ReturnsAsync(products);

            mockRepository.Setup(q => q.ExistsAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return products.Any(q => q.Id == id);
            });

            mockRepository.Setup(q => q.AddAsync(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });

            return mockRepository;
        }

    }
}
