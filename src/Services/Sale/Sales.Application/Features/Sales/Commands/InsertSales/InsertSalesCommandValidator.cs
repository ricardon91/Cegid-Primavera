using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.InsertSales
{
    public class InsertSalesCommandValidator : AbstractValidator<InsertSalesCommand>
    {
        public InsertSalesCommandValidator()
        {
            RuleFor(p => p.Unit)
                .NotEmpty()
                .WithMessage("{Unit} is required.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .WithMessage("Price is required.")
                .GreaterThan(0).WithMessage("Total Price should be greater than zero.");
        }
    }
}
