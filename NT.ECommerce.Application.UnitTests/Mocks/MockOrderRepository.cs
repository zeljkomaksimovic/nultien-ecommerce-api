using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Mocks
{
    public class MockOrderRepository
    {
        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var orders = new List<Order>
            {
                new Order
                         {
                            Id = 1,
                            Amount= 2500.99m,
                            AppliedDiscount = 250,
                            City = "Belgrade",
                            Street = "Grcica Milenka",
                            HouseNumber ="4",
                            PhoneNumber = "+381644559861",
                            CustomerId =1,
                            CreatedBy = "zmaksimovic",
                            DateCreated = DateTime.Now,
                            Status = true
                         },
                         new Order
                         {
                            Id = 2,
                            Amount= 1500.99m,
                            AppliedDiscount = 150,
                            City = "Belgrade",
                            Street = "Ustanicka",
                            HouseNumber ="128",
                            PhoneNumber = "+381644559860",
                            CustomerId =1,
                            CreatedBy = "zmaksimovic",
                            DateCreated = DateTime.Now,
                            Status = true
                         }
            };

            var mockRepository = new Mock<IOrderRepository>();

            mockRepository.Setup(q => q.GetAllAsync()).ReturnsAsync(orders);

            mockRepository.Setup(q => q.AddAsync(It.IsAny<Order>())).ReturnsAsync((Order order) =>
            {
                orders.Add(order);
                return order;
            });

            return mockRepository;
        }

    }
}
