using Customers.Application.Behaviors;
using Customers.Application.Features.Customers.Commands.UpdateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Customers.Application.Features.Customers.Commands.InsertCustomer
{
    public class InsertCustomerCommandValidator : AbstractValidator<InsertCustomerCommand>
    {
        public InsertCustomerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");

            RuleFor(p => p.Country)
                .NotEmpty().WithMessage("Country is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");
            
            RuleFor(p => p.TaxId)
                .NotEmpty().WithMessage("Tax Id is required.")
                .NotNull()
                .IsNifValid().When(p => p.Country == "Portugal");
        }
    }    
}
