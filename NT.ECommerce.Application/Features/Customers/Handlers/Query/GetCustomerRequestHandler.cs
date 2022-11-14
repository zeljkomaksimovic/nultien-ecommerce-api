using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.Features.Customers.Requests.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Customers.Handlers.Query
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerRequestHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(request.Id);
            return _mapper.Map<CustomerDto>(customer);
        }
    }
}
