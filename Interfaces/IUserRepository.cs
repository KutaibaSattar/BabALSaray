using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.DTOs;

namespace BabALSaray.Interfaces
{
    public interface IUserRepository
    {

        void Update(AppUser user);

        Task<bool> SaveAllAsync();

        Task<IEnumerable<AppUser>> GetUserAsync();

        Task<AppUser> GetUserByIdAsync (int id);
                
        Task <AppUser> GetUserByNameAsync (string username);

        Task <IEnumerable<MemberDto>> GetMembersAsync();

        Task<MemberDto> GetMemberAsync(int id);
        
        
    }
}