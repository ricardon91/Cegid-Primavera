using Customers.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Domain.Entities
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string TaxId { get; set; }
    }
}
