using BabALSaray.AppEntities;

namespace BabALSaray.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        
    }
}