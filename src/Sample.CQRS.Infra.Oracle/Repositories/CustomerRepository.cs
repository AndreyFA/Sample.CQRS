using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.CQRS.Domain.Entities;
using Sample.CQRS.Domain.Interfaces.Repositories;

namespace Sample.CQRS.Infra.Oracle.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private static long _currentId = 1;
        private static readonly ISet<Customer> Customers = new HashSet<Customer>();

        public async Task<long> InsertAsync(Customer customer)
        {
            customer.Id = _currentId;

            Customers.Add(customer);
            
            return await Task.FromResult(_currentId++);
        }

        public async Task UpdateAsync(Customer customer)
        {
            var oldCustomer = await GetByIdAsync(customer.Id);

            Customers.Remove(oldCustomer);

            await InsertAsync(customer);
        }

        public async Task<bool> ExistsAsync(Customer customer)
            => await Task.FromResult(Customers.Any(c => Equals(c.CorporateName, customer.CorporateName)));

        public async Task<Customer> GetByIdAsync(long id)
            => await Task.FromResult(Customers.FirstOrDefault(c => Equals(c.Id, id)));
    }
}