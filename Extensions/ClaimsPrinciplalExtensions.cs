using System.Linq;
using System.Security.Claims;

namespace BabALSaray.Extensions
{
    public static class ClaimsPrinciplalExtensions
    {
        public static string RetrieveEmailFromPrincipal( this ClaimsPrincipal user)
        {

            return user?.Claims?.FirstOrDefault( x => x.Type == ClaimTypes.Email)?.Value;
            
        }
    }
}