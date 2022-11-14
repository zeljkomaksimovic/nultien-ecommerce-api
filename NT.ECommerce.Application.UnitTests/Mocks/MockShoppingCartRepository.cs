using NT.ECommerce.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Mocks
{
    public class MockShoppingCartRepository
    {
        public static Mock<IShoppingCartRepository> GetShoppingCartRepository()
        {
            var cartItems = new List<ShoppingCart>
            {
                new ShoppingCart
                         {
                             Id = 1,
                             CustomerId = 1,
                             ProductId = 1,
                             Product = new Product
                         {
                             Id = 1,
                             Name = "Majica",
                             Quantity = 3,
                             UnitPrice = 1490.90m,
                             StorageType = 1,
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                new ShoppingCart
                         {
                             Id = 2,
                             CustomerId = 1,
                             ProductId = 2,
                             Product = new Product
                         {
                             Id = 2,
                             Name = "Jakna",
                             Quantity = 4,
                             UnitPrice = 21490.90m,
                             StorageType = 1,
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
            };

            var mockRepository = new Mock<IShoppingCartRepository>();

            mockRepository.Setup(q => q.GetAllAsync()).ReturnsAsync(cartItems);

            mockRepository.Setup(q => q.IsShoppingCartEmptyAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return cartItems.Where(q => q.CustomerId == id).Any();
            });

            mockRepository.Setup(q => q.GetCustomerCartItems(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return cartItems.Where(q => q.CustomerId == id).ToList();
            });

            mockRepository.Setup(q => q.RemoveShoppingCartItems(It.IsAny<List<ShoppingCart>>())).Callback((List<ShoppingCart> itemsToRemove) =>
            {
                itemsToRemove.ForEach(q => cartItems.Remove(q));
            });

            mockRepository.Setup(q => q.AddAsync(It.IsAny<ShoppingCart>())).ReturnsAsync((ShoppingCart cartItem) =>
            {
                cartItems.Add(cartItem);
                return cartItem;
            });

            return mockRepository;
        }

    }
}
