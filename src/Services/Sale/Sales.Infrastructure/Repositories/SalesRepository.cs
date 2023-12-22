using Sales.Application.Contracts.Persistence;
using Sales.Domain.Entities;
using Sales.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Repositories
{
    public class SalesRepository : RepositoryBase<SalesItems>, ISalesRepository
    {
        public SalesRepository(SalesContext dbContext) : base(dbContext)
        {
        }        
    }
}
