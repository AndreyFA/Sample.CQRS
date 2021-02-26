using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.CQRS.Application.Commands;
using Sample.CQRS.Domain.Interfaces.Common;
using Sample.CQRS.Infra.Cache.Interfaces.Repositories;
using Sample.CQRS.WebAPI.Models;

namespace Sample.CQRS.WebAPI.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly INotifications _notifications;
        private readonly ICustomerCacheRepository _customerCacheRepository;

        public CustomerController(
            IMediator mediator, 
            INotifications notifications,
            ICustomerCacheRepository customerCacheRepository)
            => (_mediator,
                _notifications,
                _customerCacheRepository) = (mediator, notifications, customerCacheRepository);

        [HttpGet("summaries")]
        public async Task<IActionResult> GetAllCustomerSummariesAsync()
        {
            var summaries = await _customerCacheRepository.GetAllCustomerSummariesAsync();

            IActionResult response = !Equals(summaries, null) && summaries.Any()
                ? Ok(summaries)
                : NoContent();

            return response;
        }

        [HttpPut("{customerId:long}/address")]
        public async Task<IActionResult> UpdateCustomerAddressAsync(long customerId,
            [FromBody] AddressModel addressViewModel)
        {
            var command = new UpdateCustomerAddressCommand(
                customerId,
                addressViewModel.Street,
                addressViewModel.Number,
                addressViewModel.Complement,
                addressViewModel.ZipCode,
                addressViewModel.Neighborhood,
                addressViewModel.City,
                addressViewModel.State);

            await _mediator.Send(command);
            
            IActionResult response = _notifications.IsSuccessfully
                ? Accepted()
                : BadRequest(_notifications.Errors);

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCustomerAsync(CustomerModel customer)
        {
            var command = new CreateNewCustomerCommand(
                customer.CorporateName, 
                customer.FantasyName, 
                customer.Address.Street, 
                customer.Address.Number,
                customer.Address.Complement, 
                customer.Address.ZipCode, 
                customer.Address.Neighborhood, 
                customer.Address.City,
                customer.Address.State);

            await _mediator.Send(command);

            IActionResult response = _notifications.IsSuccessfully
                ? Accepted()
                : BadRequest(_notifications.Errors);

            return response;
        }
    }
}