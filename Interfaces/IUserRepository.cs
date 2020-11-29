using System.Collections.Generic;
using System.Threading.Tasks;
using AppEntities;

namespace BabALSaray.Interfaces
{
    public interface IUserRepository
    {

        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUserAsync();

        Task<AppUser> GetUserByIdAsync (int id);
                
        Task <AppUser> GetUserByNameAsync (string username);
        
    }
}