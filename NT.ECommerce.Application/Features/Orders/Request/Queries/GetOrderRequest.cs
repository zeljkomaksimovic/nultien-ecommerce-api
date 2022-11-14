using MediatR;
using NT.ECommerce.Application.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Orders.Request.Queries
{
    public class GetOrderRequest : IRequest<OrderDto>
    {
        public int Id { get; set; }
    }
}
