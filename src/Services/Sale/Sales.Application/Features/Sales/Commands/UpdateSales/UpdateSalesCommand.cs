using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.UpdateSales
{
    public class UpdateSalesCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int Unit { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
