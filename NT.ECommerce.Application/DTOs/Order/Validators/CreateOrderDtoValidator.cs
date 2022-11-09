using FluentValidation;
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
        public CreateOrderDtoValidator()
        {
            RuleFor(o => o.AppliedDiscount)
                .NotNull().WithMessage("{PropertyName} cannot be null.");

            RuleFor(o => o.Amount)
                .GreaterThan(0).WithMessage("{PropertyName} must be greather then {ComparasionValue}")
                .NotNull().WithMessage("{PropertyName} cannot be null.");

        }
    }
}
