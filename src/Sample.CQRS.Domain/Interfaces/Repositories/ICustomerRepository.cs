using System.Threading.Tasks;
using Sample.CQRS.Domain.Entities;

namespace Sample.CQRS.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<long> InsertAsync(Customer customer);
        Task<bool> ExistsAsync(Customer customer);
        Task<Customer> GetByIdAsync(long id);
        Task UpdateAsync(Customer customer);
    }
}