using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class Seed
    {
        public static async Task SeedUsersAsync (UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
           if (!userManager.Users.Any())
           {
               var user = new AppUser
               {
                  DisplayName = "Kutaiba",
                  Email = "md@seraime.com",
                  UserName =  "Kutaiba",
                  Address =  new Address
                  {
                      FirstName = "Kutaiba",
                      LastName = "Sattar",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user, "Pa$$w0rd" );
              
               var user2 = new AppUser
               {
                  DisplayName = "Huda",
                  Email = "info@seraime.com",
                  UserName =  "Kutaiba",
                  Address =  new Address
                  {
                      FirstName = "Kutaiba",
                      LastName = "Sattar",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user2, "Pa$$w0rd" );
              
                var user3 = new AppUser
               {
                  DisplayName = "Abd",
                  Email = "support@seraime.com",
                  UserName =  "Abd",
                  Address =  new Address
                  {
                      FirstName = "Abd",
                      LastName = "Kutaiba",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user3, "Pa$$w0rd");

                  var user4 = new AppUser
               {
                  DisplayName = "admin",
                  Email = "admin@seraime.com",
                  UserName =  "Kutaiba",
                  Address =  new Address
                  {
                      FirstName = "Kutaiba",
                      LastName = "Sattar",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user3, "Pa$$w0rd");


           } 

         
          var users = await userManager.Users.ToListAsync();
          
           if (!await userManager.Users.AnyAsync()) return;


                
                 var roles = new List<AppRole>
            {
                new  AppRole {Name = "Member"},
                new  AppRole {Name = "Admin"},
                new  AppRole {Name = "Moderator"},

            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users){
                await userManager.AddToRoleAsync(user, "Member");

            }

            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin,"Pa$$w0rd");
            
            await userManager.AddToRolesAsync(admin, new[] {"Admin","Moderator"});
            



        }  
    }
}