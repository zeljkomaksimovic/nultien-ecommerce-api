using FluentValidation;
using NT.ECommerce.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.ShoppingCart.Validators
{
    public class CreateShoppingCartDtoValidator : AbstractValidator<CreateShoppingCartDto>
    {
        public CreateShoppingCartDtoValidator(ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            RuleFor(s => s.CustomerId)
                .MustAsync(async (id, token) => await customerRepository.ExistsAsync(id)).WithMessage("{PropertyName} does not exist.");

            RuleFor(s => s.ProductId)
                .MustAsync(async (id, token) => await productRepository.ExistsAsync(id)).WithMessage("{PropertyName} does not exist.");

            RuleFor(s => s.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName} must be greather then {ComparisonValue}");
        }
    }
}
