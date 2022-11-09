using MediatR;
using NT.ECommerce.Application.DTOs.Customer;
using NT.ECommerce.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Customers.Requests.Command
{
    public class CreateCustomerCommand : IRequest<CommandResponse>
    {
        public CreateCustomerDto? CreateCustomerDto { get; set; }
    }
}
