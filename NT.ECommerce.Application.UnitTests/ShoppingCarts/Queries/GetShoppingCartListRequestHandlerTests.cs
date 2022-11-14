using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Features.ShoppingCarts.Handlers.Queries;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.ShoppingCarts.Queries
{
    public class GetShoppingCartListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShoppingCartRepository> _mockRepository;

        public GetShoppingCartListRequestHandlerTests()
        {
            _mockRepository = MockShoppingCartRepository.GetShoppingCartRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetShoppingCart_ShouldBe_Valid()
        {
            var handler = new GetCartItemsListRequestHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetCartItemsListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ShoppingCartDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
