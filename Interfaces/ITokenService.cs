using System.Threading.Tasks;
using BabALSaray.AppEntities;

namespace BabALSaray.Interfaces
{
    public interface ITokenService
    {
       Task<string> CreateToken(AppUser user);
        
    }
}