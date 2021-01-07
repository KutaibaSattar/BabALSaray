using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BabALSaray.AppEntities
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> UserRoles { get; set; }
        
    }
}