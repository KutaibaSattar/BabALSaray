using AppEntities;

namespace BabALSaray.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
        
    }
}