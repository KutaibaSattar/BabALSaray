using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IUserRepository
    {
       /*  And the updates is not an async method, because all that's going to do is update the tracking status
        in entity framework to say that something has changed, but all of the other ones are tasks. */
        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUserAsync();

        Task<AppUser> GetUserByIdAsync (int id);
                
        Task <AppUser> GetUserByNameAsync (string username);

        Task <IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto> GetMemberAsync(int id);
        
        
    }
}