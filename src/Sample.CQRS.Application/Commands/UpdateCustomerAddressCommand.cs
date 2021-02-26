using MediatR;

namespace Sample.CQRS.Application.Commands
{
    public class UpdateCustomerAddressCommand : 
        IRequest<Unit>, 
        INotification
    {
        public UpdateCustomerAddressCommand(long customerId, string street, string number, string complement, string zipCode, string neighborhood, string city, string state)
        {
            CustomerId = customerId;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public long CustomerId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}