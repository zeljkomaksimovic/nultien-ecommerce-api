using MediatR;
using NT.ECommerce.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Customers.Requests.Query
{
    public class GetCustomerRequest : IRequest<CustomerDto>
    {
        public int Id { get; set; }
    }
}
