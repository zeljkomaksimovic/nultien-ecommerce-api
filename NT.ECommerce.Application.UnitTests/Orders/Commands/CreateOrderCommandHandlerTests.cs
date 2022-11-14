using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.Order;
using NT.ECommerce.Application.Features.Orders.Handler.Command;
using NT.ECommerce.Application.Features.Orders.Request.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Orders.Commands
{
    public class CreateOrderCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IShoppingCartRepository> _mockShoppingCartRepository;
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly CreateOrderDto _createOrderDto;

        public CreateOrderCommandHandlerTests()
        {
            _mockOrderRepository = MockOrderRepository.GetOrderRepository();
            _mockShoppingCartRepository = MockShoppingCartRepository.GetShoppingCartRepository();
            _mockCustomerRepository = MockCustomerRepository.GetCustomerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createOrderDto = new CreateOrderDto
            {
                City = "Belgrade",
                Street = "Grcica Milenka",
                HouseNumber = "4",
                PhoneNumber = "+381644559861",
                CustomerId = 1
            };
        }

        [Fact]
        public async Task CreateCustomer_ShouldBe_Valid()
        {
            var handler = new CreateOrdersCommandHandler(_mockOrderRepository.Object, _mockCustomerRepository.Object, _mockShoppingCartRepository.Object, _mapper);

            var result = await handler.Handle(new CreateOrdersCommand { CreateOrderDto = _createOrderDto }, CancellationToken.None);

            var orders = await _mockOrderRepository.Object.GetAllAsync();
            var customerCartItems = await _mockShoppingCartRepository.Object.GetCustomerCartItems(_createOrderDto.CustomerId);

            result.ShouldBeOfType<OrderCommandResponse>();
            result.Success.ShouldBeTrue();

            orders.Count.ShouldBe(3);
            customerCartItems.Count.ShouldBe(0);
        }
    }
}
