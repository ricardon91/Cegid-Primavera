using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Features.Customers.Queries
{
    public class CustomersVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string TaxId { get; set; }
    }
}
