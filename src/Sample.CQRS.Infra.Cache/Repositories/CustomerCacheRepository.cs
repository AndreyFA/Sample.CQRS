using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.CQRS.Infra.Cache.Interfaces.Repositories;
using Sample.CQRS.Infra.Cache.Models;

namespace Sample.CQRS.Infra.Cache.Repositories
{
    public class CustomerCacheRepository : ICustomerCacheRepository
    {
        private static readonly ISet<CustomerSummary> CustomerSummaries = new HashSet<CustomerSummary>();
        
        public async Task InsertAsync(CustomerSummary customerSummary)
            => await Task.FromResult(CustomerSummaries.Add(customerSummary));

        public async Task UpdateCustomerSummaryAsync(CustomerSummary customerSummary)
        {
            var oldCustomer =
                CustomerSummaries.FirstOrDefault(c => Equals(c.CorporateName, customerSummary.CorporateName));

            CustomerSummaries.Remove(oldCustomer);

            await InsertAsync(customerSummary);
        }

        public async Task<IEnumerable<CustomerSummary>> GetAllCustomerSummariesAsync()
            => await Task.FromResult(CustomerSummaries);
    }
}