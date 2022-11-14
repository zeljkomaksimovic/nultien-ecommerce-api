using AutoMapper;
using Moq;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Mocks
{
    public class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customers = new List<Customer>
            {
                new Customer
                         {
                             Id = 1,
                             FirstName = "Marko",
                             LastName = "Markovic",
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         },
                         new Customer
                         {
                             Id = 2,
                             FirstName = "Stefan",
                             LastName = "Milosevic",
                             CreatedBy = "zmaksimovic",
                             DateCreated = DateTime.Now,
                             Status = true
                         }
            };

            var mockRepository = new Mock<ICustomerRepository>();

            mockRepository.Setup(q => q.GetAllAsync()).ReturnsAsync(customers);

            mockRepository.Setup(q => q.ExistsAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return customers.Any(q => q.Id == id);               
            });

            mockRepository.Setup(q => q.AddAsync(It.IsAny<Customer>())).ReturnsAsync((Customer customer) => 
            {
                customers.Add(customer);
                return customer;
            });

            return mockRepository;
        }
    }
}
