using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.Order.Validators;
using NT.ECommerce.Application.Features.Orders.Request.Command;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Orders.Handler.Command
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderDtoValidator();
            var validate = await validator.ValidateAsync(request.CreateOrderDto!);

            if (validate.IsValid is false)
            {
                throw new Exception();
            }

            var order = _mapper.Map<Order>(request.CreateOrderDto);
            order = await _orderRepository.Add(order);

            return order.Id;
        }
    }
}
