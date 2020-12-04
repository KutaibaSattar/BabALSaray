using System.ComponentModel.DataAnnotations;

namespace BabALSaray.DTOs
{
    public class LoginDto
    {
           [Required]
            public string Username { get; set; }
            
            [Required]
            public string Password { get; set; }


    }
}