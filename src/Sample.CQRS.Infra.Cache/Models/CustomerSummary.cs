namespace Sample.CQRS.Infra.Cache.Models
{
    public class CustomerSummary
    {
        public long CustomerId { get; set; }
        public string CorporateName { get; set; }
        
        public long AddressId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}