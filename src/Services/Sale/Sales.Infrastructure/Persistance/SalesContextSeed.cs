using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Persistance
{
    public class SalesContextSeed
    {
        public static async Task SeedAsync(SalesContext customerContext, ILogger<SalesContextSeed> logger)
        {
            if (!customerContext.Sales.Any())
            {
                customerContext.Sales.AddRange(GetPreconfiguredSales());
                await customerContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(SalesContext).Name);
            }
        }

        private static IEnumerable<SalesItems> GetPreconfiguredSales()
        {
            return new List<SalesItems>
            {
                new SalesItems() {Unit = 2, Description = "iPhone 15 Plus", Price = 1139, TotalPrice = 2278 }
            };
        }
    }
}
