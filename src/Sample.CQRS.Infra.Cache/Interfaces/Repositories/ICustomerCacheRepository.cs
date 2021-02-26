using System.Collections.Generic;
using System.Threading.Tasks;
using Sample.CQRS.Infra.Cache.Models;

namespace Sample.CQRS.Infra.Cache.Interfaces.Repositories
{
    public interface ICustomerCacheRepository
    {
        Task<IEnumerable<CustomerSummary>> GetAllCustomerSummariesAsync();
        Task InsertAsync(CustomerSummary customerSummary);
        Task UpdateCustomerSummaryAsync(CustomerSummary customerSummary);
    }
}