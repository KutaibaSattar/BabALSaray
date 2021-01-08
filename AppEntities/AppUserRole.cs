using Microsoft.AspNetCore.Identity;

namespace BabALSaray.AppEntities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
        
    }
}