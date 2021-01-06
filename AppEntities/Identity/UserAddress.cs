using System.ComponentModel.DataAnnotations;

namespace BabALSaray.AppEntities.Identity
{
    public class UserAddress
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Email { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [Required]
        public string StoreUserId { get; set; } // one-to-one relation

        public StoreUser StoreUser { get; set; }

        

    }
}