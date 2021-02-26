using System.Threading.Tasks;
using Sample.CQRS.Domain.Entities;

namespace Sample.CQRS.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task CreateNewCustomerAsync(Customer customer);
        Task ChangeAddressAsync(long customerId, Address address);
    }
}