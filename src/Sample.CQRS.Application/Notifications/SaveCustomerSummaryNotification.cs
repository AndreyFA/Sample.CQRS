using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.CQRS.Application.Commands;
using Sample.CQRS.Domain.Interfaces.Repositories;
using Sample.CQRS.Infra.Cache.Interfaces.Repositories;
using Sample.CQRS.Infra.Cache.Models;

namespace Sample.CQRS.Application.Notifications
{
    public class SaveCustomerSummaryNotification :
        INotificationHandler<CreateNewCustomerCommand>,
        INotificationHandler<UpdateCustomerAddressCommand>
    {
        private readonly ICustomerCacheRepository _customerCacheRepository;
        private readonly ICustomerRepository _customerRepository;

        public SaveCustomerSummaryNotification(ICustomerCacheRepository customerCacheRepository, ICustomerRepository customerRepository)
            => (_customerCacheRepository, _customerRepository) = (customerCacheRepository, customerRepository);
        
        public async Task Handle(CreateNewCustomerCommand notification, CancellationToken cancellationToken)
        {
            var customerSummary = new CustomerSummary()
            {
                CorporateName = notification.CorporateName,
                City = notification.City,
                Street = notification.Street,
                Number = notification.Number,
                Complement = notification.Complement,
                Neighborhood = notification.Neighborhood,
                ZipCode = notification.ZipCode,
                State = notification.State
            };

            await _customerCacheRepository.InsertAsync(customerSummary);
        }

        public async Task Handle(UpdateCustomerAddressCommand notification, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(notification.CustomerId);
            
            var customerSummary = new CustomerSummary()
            {
                CorporateName = customer.CorporateName,
                City = notification.City,
                Street = notification.Street,
                Number = notification.Number,
                Complement = notification.Complement,
                Neighborhood = notification.Neighborhood,
                ZipCode = notification.ZipCode,
                State = notification.State
            };

           await _customerCacheRepository.UpdateCustomerSummaryAsync(customerSummary);
        }
    }
}