using MediatR;

namespace Sample.CQRS.Application.Commands
{
    public class CreateNewCustomerCommand : 
        IRequest<Unit>, 
        INotification
    {
        public CreateNewCustomerCommand(string corporateName, 
            string fantasyName, 
            string street, 
            string number,
            string complement,
            string zipCode,
            string neighborhood,
            string city,
            string state)
        {
            CorporateName = corporateName;
            FantasyName = fantasyName;
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }

        public string CorporateName { get; set; }
        public string FantasyName { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}