using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BabALSaray.AppEntities.Identity
{
    public class StoreIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync (UserManager<StoreUser> userManager)
        {
           if (!userManager.Users.Any())
           {
               var user = new StoreUser
               {
                  DisplayName = "Kutaiba",
                  Email = "md@seraime.com",
                  UserName =  "Kutaiba",
                  Address =  new UserAddress
                  {
                      FirstName = "Kutaiba",
                      LastName = "Sattar",
                      Country = "UAE",
                      City = "Dubai"

                  }

               };

               await userManager.CreateAsync(user, "Pa$$w0rd" );

           } 

        }  
    }
}