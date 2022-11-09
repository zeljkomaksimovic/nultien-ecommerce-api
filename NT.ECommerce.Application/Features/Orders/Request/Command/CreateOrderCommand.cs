using MediatR;
using NT.ECommerce.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Orders.Request.Command
{
    public class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderDto? CreateOrderDto { get; set; }
    }
}
