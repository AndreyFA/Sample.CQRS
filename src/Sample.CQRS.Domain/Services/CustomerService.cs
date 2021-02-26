using System.Threading.Tasks;
using Sample.CQRS.Domain.Entities;
using Sample.CQRS.Domain.Interfaces.Common;
using Sample.CQRS.Domain.Interfaces.Repositories;
using Sample.CQRS.Domain.Interfaces.Services;

namespace Sample.CQRS.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly INotifications _notifications;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(INotifications notifications, ICustomerRepository customerRepository)
            => (_notifications, _customerRepository) = (notifications, customerRepository);

        public async Task CreateNewCustomerAsync(Customer customer)
        {
            if (!customer.IsValid())
            {
                _notifications.AddError("Invalid customer.");
                return;
            }

            if (await _customerRepository.ExistsAsync(customer))
            {
                _notifications.AddError("Customer already exists.");
                return;
            }
            
            await _customerRepository.InsertAsync(customer);
        }

        public async Task ChangeAddressAsync(long customerId, Address address)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);

            if (Equals(customer, null))
            {
                _notifications.AddError("Customer not found.");
                return;
            }
            
            customer.ChangeAddress(address);

            await _customerRepository.InsertAsync(customer);
        }
    }
}