using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Features.Products.Handlers.Query;
using NT.ECommerce.Application.Features.Products.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Products.Queries
{
    public class GetProductsListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockRepository;

        public GetProductsListRequestHandlerTests()
        {
            _mockRepository = MockProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProducts_ShouldBe_Valid()
        {
            var handler = new GetProductsListRequestHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetProductsListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
