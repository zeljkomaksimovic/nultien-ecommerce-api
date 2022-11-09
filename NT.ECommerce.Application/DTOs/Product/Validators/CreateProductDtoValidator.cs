using FluentValidation;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Product.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparasionValue} characters.")
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty.");

            RuleFor(p => p.UnitPrice)
                .GreaterThan(0).WithMessage("{PropertyName} must be greather then {ComparasionValue}")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(p => p.Quantity)
                .GreaterThan(0).WithMessage("{PropertyName} must be greather then {ComparasionValue}")
                .NotNull().WithMessage("{PropertyName} cannot be null.");
        }
    }
}
