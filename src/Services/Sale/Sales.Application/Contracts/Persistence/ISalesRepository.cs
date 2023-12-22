using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Contracts.Persistence
{
    public interface ISalesRepository : IAsyncRepository<SalesItems>
    {

    }
}
