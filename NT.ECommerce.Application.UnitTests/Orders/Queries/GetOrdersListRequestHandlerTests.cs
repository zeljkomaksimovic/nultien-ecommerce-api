using NT.ECommerce.Application.DTOs.Order;
using NT.ECommerce.Application.Features.Orders.Handler.Queries;
using NT.ECommerce.Application.Features.Orders.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Orders.Queries
{
    public class GetOrdersListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOrderRepository> _mockRepository;

        public GetOrdersListRequestHandlerTests()
        {
            _mockRepository = MockOrderRepository.GetOrderRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetOrdersers_ShouldBe_Valid()
        {
            var handler = new GetOrdersListRequestHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetOrdersListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<OrderDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
