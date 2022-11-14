using FluentValidation;
using NT.ECommerce.Application.Contracts.Persistance;
using NT.ECommerce.Application.Contracts.Persistence;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Order.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator(ICustomerRepository customerRepository, IShoppingCartRepository shoppingCartRepository)
        {
            RuleFor(o => o.City)
           .NotEmpty().WithMessage("{PropertyName} cannot be null.");

            RuleFor(o => o.Street)
                .NotEmpty().WithMessage("{PropertyName} cannot be null.");

            RuleFor(o => o.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} cannot be null.");

            RuleFor(o => o.CustomerId)
                .MustAsync(async (id, token) => await customerRepository.ExistsAsync(id)).WithMessage("{PropertyName} does not exist.")
                .MustAsync(async (id, token) => await shoppingCartRepository.IsShoppingCartEmptyAsync(id)).WithMessage("Customer's shopping cart is empty.");

        }
    }
}
