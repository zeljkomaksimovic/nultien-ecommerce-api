using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.Customer.Validators;
using NT.ECommerce.Application.Features.Customers.Requests.Command;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Customers.Handlers.Command
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerDtoValidator();
            var validate = await validator.ValidateAsync(request.CreateCustomerDto!);

            if (validate.IsValid is false)
            {
                throw new Exception();
            }

            var customer = _mapper.Map<Customer>(request.CreateCustomerDto!);
            customer = await _customerRepository.Add(customer);

            return customer.Id;
        }
    }
}
