using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Product;
using NT.ECommerce.Application.Enums;
using NT.ECommerce.Application.Features.Products.Handlers.Command;
using NT.ECommerce.Application.Features.Products.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Products.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly CreateProductDto _createProductDto;

        public CreateProductCommandHandlerTests()
        {
            _mockRepository = MockProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createProductDto = new CreateProductDto
            {
                Name = "Hoodie",
                Quantity = 3,
                UnitPrice = 2490.90m,
                StorageType = ProductStorageType.Local
            };
        }

        [Fact]
        public async Task CreateProduct_ShouldBe_Valid()
        {
            var handler = new CreateProductCommandHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new CreateProductCommand { CreateProductDto = _createProductDto }, CancellationToken.None);

            var products = await _mockRepository.Object.GetAllAsync();

            result.ShouldBeOfType<CommandResponse>();
            result.ShouldBeEquivalentTo(new CommandResponse
            {
                Success = true,
                Message = "Product is Successfuly created.",
                Id = 0
            });
            products.Count.ShouldBe(3);
        }
    }
}
