using AutoMapper;
using Moq;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.Features.Customers.Handlers.Query;
using NT.ECommerce.Application.Features.Customers.Requests.Query;
using NT.ECommerce.Application.Profiles;
using NT.ECommerce.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Customers.Queries
{
    public class GetCustomersListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockRepository;

        public GetCustomersListRequestHandlerTests()
        {
            _mockRepository = MockCustomerRepository.GetCustomerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCustomers_ShouldBe_Valid()
        {
            var handler = new GetCustomersListRequestHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetCustomersListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CustomerDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
