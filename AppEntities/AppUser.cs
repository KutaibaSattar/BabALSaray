using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BabALSaray.AppEntities
{
    public class AppUser : IdentityUser<int>
    {
             
        public string DisplayName {get;set;}
        public DateTime Created { get; set; }   = DateTime.Now;

        public DateTime LastActive { get; set; } =  DateTime.Now; 

        public Address Address {get;set;}    
      
         public ICollection<AppUserRole> UserRoles { get; set; }

       
    }
}