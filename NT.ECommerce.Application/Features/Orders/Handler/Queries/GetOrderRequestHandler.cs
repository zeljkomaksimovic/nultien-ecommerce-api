using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Application.DTOs.Order;
using NT.ECommerce.Application.Features.Orders.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Orders.Handler.Queries
{
    public class GetOrderRequestHandler : IRequestHandler<GetOrderRequest, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderRequestHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetAsync(request.Id);
            return _mapper.Map<OrderDto>(order);
        }
    }
}
