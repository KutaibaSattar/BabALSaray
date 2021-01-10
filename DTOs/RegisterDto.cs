using System.ComponentModel.DataAnnotations;

namespace BabALSaray.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email {get;set; }
        
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$")]
        [StringLength(8, MinimumLength=4)]
        public string Password { get; set; }

    }
}