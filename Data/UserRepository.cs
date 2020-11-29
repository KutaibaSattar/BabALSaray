using System.Collections.Generic;
using System.Threading.Tasks;
using AppEntities;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

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