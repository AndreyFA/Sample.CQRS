using System.ComponentModel.DataAnnotations;

namespace Sample.CQRS.WebAPI.Models
{
    public class AddressModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Street { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Number { get; set; }
        
        public string Complement { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string ZipCode { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Neighborhood { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string City { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string State { get; set; }
    }
}