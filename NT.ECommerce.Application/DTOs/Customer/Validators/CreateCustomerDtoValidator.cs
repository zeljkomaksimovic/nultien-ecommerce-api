﻿using FluentValidation;
using NT.ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.ECommerce.Application.DTOs.Customer.Validators
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(c => c.FirstName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.")
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty.");

            RuleFor(c => c.LastName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.")
                .NotEmpty().WithMessage("{PropertyName} cannot be null or empty.");
        }
    }
}
