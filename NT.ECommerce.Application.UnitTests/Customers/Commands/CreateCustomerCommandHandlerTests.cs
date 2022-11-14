using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.Features.Customers.Handlers.Command;
using NT.ECommerce.Application.Features.Customers.Requests.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.UnitTests.Customers.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerRepository> _mockRepository;
        private readonly CreateCustomerDto _createCustomerDto;

        public CreateCustomerCommandHandlerTests()
        {
            _mockRepository = MockCustomerRepository.GetCustomerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _createCustomerDto = new CreateCustomerDto
            {
                FirstName = "Stefan",
                LastName = "Milosevic"
            };
        }

        [Fact]
        public async Task CreateCustomer_ShouldBe_Valid()
        {
            var handler = new CreateCustomerCommandHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new CreateCustomerCommand { CreateCustomerDto = _createCustomerDto }, CancellationToken.None);

            var customers = await _mockRepository.Object.GetAllAsync();

            result.ShouldBeOfType<CommandResponse>();
            result.ShouldBeEquivalentTo(new CommandResponse
            {
                Success = true,
                Message = "Customer is Successfuly created.",
                Id = 0
            });
            customers.Count.ShouldBe(3);
        }
    }
}
