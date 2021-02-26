using System.ComponentModel.DataAnnotations;

namespace Sample.CQRS.WebAPI.Models
{
    public class CustomerModel
    {
        [Required(AllowEmptyStrings = false)]
        public string CorporateName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string FantasyName { get; set; }
        
        [Required]
        public AddressModel Address { get; set; }
    }
}