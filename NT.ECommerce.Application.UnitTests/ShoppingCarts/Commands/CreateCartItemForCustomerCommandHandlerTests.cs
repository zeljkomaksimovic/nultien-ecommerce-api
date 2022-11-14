using NT.ECommerce.Application.Contracts;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.ShoppingCart;
using NT.ECommerce.Application.Features.ShoppingCarts.Handlers.Command;
using NT.ECommerce.Application.Features.ShoppingCarts.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.ShoppingCarts.Commands
{
    public class CreateCartItemForCustomerCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IShoppingCartRepository> _mockShoppingCartRepository;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<ISupplierRepository> _mockSupplierRepository;
        private readonly CreateShoppingCartDto _createShoppingCartDto;

        public CreateCartItemForCustomerCommandHandlerTests()
        {
            _mockShoppingCartRepository = MockShoppingCartRepository.GetShoppingCartRepository();
            _mockCustomerRepository = MockCustomerRepository.GetCustomerRepository();
            _mockProductRepository = MockProductRepository.GetProductRepository();
            _mockSupplierRepository = MockSupplierRepository.GetSupplierRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createShoppingCartDto = new CreateShoppingCartDto
            {
                CustomerId = 1,
                ProductId = 1,
                Quantity = 2
            };
        }

        [Fact]
        public async Task CreateCartItem_ShouldBe_Valid()
        {
            var handler = new CreateCartItemForCustomerCommandHandler(
                _mockCustomerRepository.Object, 
                _mockShoppingCartRepository.Object, 
                _mockProductRepository.Object,
                _mockSupplierRepository.Object,
                _mapper);

            var result = await handler.Handle(new CreateCartItemForCustomerCommand { CreateShoppingCartDto = _createShoppingCartDto }, CancellationToken.None);

            var cartItems = await _mockShoppingCartRepository.Object.GetAllAsync();

            result.ShouldBeOfType<CommandResponse>();
            result.Success.ShouldBeTrue();
            cartItems.Count.ShouldBe(3);
        }
    }
}
