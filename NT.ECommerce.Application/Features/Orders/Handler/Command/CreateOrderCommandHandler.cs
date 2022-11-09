using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.DTOs.Order.Validators;
using NT.ECommerce.Application.Features.Orders.Request.Command;
using NT.ECommerce.Application.Responses;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.Features.Orders.Handler.Command
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse();
            var validator = new CreateOrderDtoValidator();
            var validate = await validator.ValidateAsync(request.CreateOrderDto!);

            if (validate.IsValid is false)
            {
                response.Success = false;
                response.Message = "Failed to create Customer.";
                response.Errors = validate.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var order = _mapper.Map<Order>(request.CreateOrderDto);
                order = await _orderRepository.AddAsync(order);

                response.Success = false;
                response.Message = "Customer is Successfuly created.";
                response.Id = response.Id;
            }
          
            return response;
        }
    }
}
