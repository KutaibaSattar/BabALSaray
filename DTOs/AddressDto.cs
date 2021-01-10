using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class AddressDto
    {
     
    [Required]
    public string Line1 { get; set; }
   
   [Required]
    public string Line2 { get; set; }
   
   [Required]
    public string Region { get; set; }
   
   [Required]
    public string City { get; set; }
   
    [Required]
    public string Country { get; set;}
       


        
    }
}