using System;

namespace Sample.CQRS.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string CorporateName { get; private set; }
        public string FantasyName { get; private set; }
        public Address Address { get; private set; }
        
        public Customer(string corporateName, string fantasyName, Address address)
        {
            CorporateName = corporateName;
            FantasyName = fantasyName;
            Address = address;
        }

        public void ChangeAddress(Address address)
        {
            if (!address.IsValid())
                throw new InvalidOperationException("Invalid address.");

            Address = address;
        }

        public bool IsValid() => Address.IsValid();
    }
}