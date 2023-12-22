using Microsoft.EntityFrameworkCore;
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

        //public async Task<IEnumerable<SalesItems>> GetSalesByCustomerId(int id)
        //{
        //    var salesList = await _dbContext.Sales.Where(s => s.CustomerId == id).ToListAsync();

        //    return salesList;
        //}
    }
}
