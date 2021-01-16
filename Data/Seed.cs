using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.AppEntities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class Seed
    {
        public static async Task SeedUsersAsync (UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, DataContext context)
        {
          
          if (! context.OrderMethods.Any())
          {
              var item =
              context.OrderMethods.Add( new OrderMethod {ShortName="Installation"});
              context.SaveChanges();

          }
          
          
           if (!userManager.Users.Any())
           {
               var user = new AppUser
               {
                  UserName =  "kutaiba",
                  DisplayName = "Kutaiba",
                  Email = "md@seraime.com",
                
                  Address =  new Address
                  {
                      Line1="Sharjah",
                      Line2 = "Majaz",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user, "Pa$$w0rd" );
              
               var user2 = new AppUser
               {
                  UserName =  "huda",
                  DisplayName = "Huda",
                  Email = "info@seraime.com",
                  
                  Address =  new Address
                  {
                      Line1="Sharjah",
                      Line2 = "Majaz",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user2, "Pa$$w0rd" );
              
                var user3 = new AppUser
               {
                  UserName =  "abd",
                  DisplayName = "Abd",
                  Email = "support@seraime.com",
                 
                  Address =  new Address
                  {
                      Line1="Sharjah",
                      Line2 = "Majaz",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(user3, "Pa$$w0rd");

                


           

         
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

            foreach (var userAccount in users){
                await userManager.AddToRoleAsync(userAccount, "Member");

            }

             var admin = new AppUser
               {
                 UserName =  "admin",
                  DisplayName = "admin",
                  Email = "admin@seraime.com",
                 
                  Address =  new Address
                  {
                      Line1="Sharjah",
                      Line2 = "Majaz",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };
               await userManager.CreateAsync(admin, "Pa$$w0rd");
           
                     
            
            await userManager.AddToRolesAsync(admin, new[] {"Admin","Moderator"});
            
        } 


        }  
    }
}