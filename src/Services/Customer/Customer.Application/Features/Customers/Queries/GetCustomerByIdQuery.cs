using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomersVm>
    {
        public int Id { get; set; }
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
