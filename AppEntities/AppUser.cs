using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BabALSaray.AppEntities
{
    public class AppUser : IdentityUser<int>
    {
             
        public DateTime Created { get; set; }   = DateTime.Now;

        public DateTime LastActive { get; set; } =  DateTime.Now;     
      
         public ICollection<AppUserRole> UserRoles { get; set; }

       
    }
}