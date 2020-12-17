using System.Collections.Generic;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BabALSaray.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(int id)
        {
             return await _context.Users.Where(a => a.Id == id).ProjectTo<MemberDto> (_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        


        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id) ;
        }


        public async Task<AppUser> GetUserByNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync( n => n.UserName == username) ;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() >0 ;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified ;
        }
    }
}