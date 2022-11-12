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
    public class GetCustomersListRequestHandler : IRequestHandler<GetCustomersListRequest, List<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListRequestHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetCustomersListRequest request, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }
    }
}
