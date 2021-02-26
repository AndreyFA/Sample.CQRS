namespace Sample.CQRS.Domain.Entities
{
    public class Address
    {
        public Address(string street, string number, string complement, string zipCode, string neighborhood, string city, string state)
        {
            Street = street;
            Number = number;
            Complement = complement;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            City = city;
            State = state;
        }
        
        public string Street { get; }
        public string Number { get; }
        public string Complement { get; }
        public string ZipCode { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public string State { get; }

        public bool IsValid() => true;
    }
}