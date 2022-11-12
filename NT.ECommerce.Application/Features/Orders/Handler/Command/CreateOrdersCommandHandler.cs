using AutoMapper;
using MediatR;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.Contracts.Persistence;
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
    public class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand, CommandResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public CreateOrdersCommandHandler(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IShoppingCartRepository shoppingCartRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<CommandResponse> Handle(CreateOrdersCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResponse();
            var customerExists = await _customerRepository.ExistsAsync(request.CreateOrderDto!.CustomerId);
            var validator = new CreateOrderDtoValidator(_customerRepository);
            var validate = await validator.ValidateAsync(request.CreateOrderDto);

            if (validate.IsValid is true)
            {
                var order = _mapper.Map<Order>(request.CreateOrderDto);
                var customerCartItems = await _shoppingCartRepository.GetCustomerCartItems(request.CreateOrderDto.CustomerId);
                if(customerCartItems.Any() is true)
                {
                    order.Amount = customerCartItems.Sum(x => x.Product!.UnitPrice);
                    order = CalculateDiscount(order, customerCartItems);
                    //TODO: Check why does not insert data in dbo.OrderProducts
                    order = await _orderRepository.AddAsync(order);

                    if (order is not null)
                    {
                        await _shoppingCartRepository.EmptyShoppingCart(customerCartItems);

                        response.Id = order.Id;
                        response.Success = true;
                        response.Message = "Order is Successfuly created.";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Failed to create Order.";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed to create Order. Shoping cart is empty.";
                    response.Errors = validate.Errors.Select(q => q.ErrorMessage).ToList();
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Failed to create Order. Customer does not exists.";
                response.Errors = validate.Errors.Select(q => q.ErrorMessage).ToList();
            }

            return response;
        }

        private Order CalculateDiscount(Order order, List<ShoppingCart> customerCartItems)
        {
            if (DateTime.Now.TimeOfDay >= new TimeSpan(16, 0, 0) && DateTime.Now.TimeOfDay <= new TimeSpan(17, 0, 0))
            {               
                customerCartItems.ForEach(c =>
                {
                    order.OrderProducts!.Add(new() { Product = c.Product });
                });

                int lastDigit;

                if (int.TryParse(order.PhoneNumber!.Substring(order.PhoneNumber.Length - 1), out lastDigit))
                {
                    if (lastDigit == 0)
                    {
                        order.AppliedDiscount = (order.Amount * 30 / 100);
                    }
                    else
                    {
                        switch (lastDigit % 2)
                        {
                            case 0:
                                order.AppliedDiscount = (order.Amount * 20 / 100);
                                break;
                            case 1:
                                order.AppliedDiscount = (order.Amount * 10 / 100);
                                break;
                        }
                    }

                    order.Amount -= order.AppliedDiscount;
                }
            }

            return order;
        }
    }
}
