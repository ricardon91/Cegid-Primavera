using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.UpdateSales
{
    public class UpdateSalesCommandValidator : AbstractValidator<UpdateSalesCommand>
    {
        public UpdateSalesCommandValidator()
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
                .GreaterThan(0).WithMessage("Price should be greater than zero.");
        }
    }
}
