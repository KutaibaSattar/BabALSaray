using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using Microsoft.AspNetCore.Identity;

namespace BabALSaray.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByEmailWithAssressAsync(this UserManager<AppUser> 
        input , ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault( x => x.Type == ClaimTypes.Email)?.Value;
            

        }
    }
}