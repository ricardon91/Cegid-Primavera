using Customers.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Infrastructure.Persistence
{
    public class CustomerContextSeed
    {
        public static async Task SeedAsync(CustomerContext customerContext, ILogger<CustomerContextSeed> logger)
        {
            if (!customerContext.Customers.Any())
            {
                customerContext.Customers.AddRange(GetPreconfiguredCustomers());
                await customerContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CustomerContext).Name);
            }
        }

        private static IEnumerable<Customer> GetPreconfiguredCustomers()
        {
            return new List<Customer>
            {
                new Customer() {Name = "Ricardo", Country = "Portugal", TaxId = "318063212" }
            };
        }
    }
}
