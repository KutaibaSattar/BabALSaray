using Microsoft.AspNetCore.Identity;

namespace BabALSaray.AppEntities.Identity
{
    public class StoreUser : IdentityUser  // all details in IdentityUser
    {
      public string DisplayName { get; set; }

      public UserAddress Address { get; set; }  

     
        
    }
}