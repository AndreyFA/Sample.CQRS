using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.CQRS.Application.Commands;
using Sample.CQRS.Domain.Entities;
using Sample.CQRS.Domain.Interfaces.Services;

namespace Sample.CQRS.Application.Handlers
{
    public class CustomerHandler : 
        IRequestHandler<CreateNewCustomerCommand, Unit>,
        IRequestHandler<UpdateCustomerAddressCommand, Unit>
    {
        private readonly ICustomerService _customerService;
        private readonly IMediator _mediator;

        public CustomerHandler(ICustomerService customerService, IMediator mediator) 
            => (_customerService, _mediator) = (customerService, mediator);
        
        public async Task<Unit> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(
                request.CorporateName, 
                request.FantasyName,
                new Address(
                    request.Street, 
                    request.Number, 
                    request.Complement, 
                    request.ZipCode, 
                    request.Neighborhood,
                    request.City, 
                    request.State));

            await _customerService.CreateNewCustomerAsync(customer);

            await _mediator.Publish(request, cancellationToken);
            
            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var address =  new Address(
                request.Street, 
                request.Number, 
                request.Complement, 
                request.ZipCode, 
                request.Neighborhood,
                request.City, 
                request.State);

            await _customerService.ChangeAddressAsync(request.CustomerId, address);

            await _mediator.Publish(request, cancellationToken);
            
            return Unit.Value;
        }
    }
}