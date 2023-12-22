using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Features.Sales.Commands.DeleteSales
{
    public class DeleteSalesCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
