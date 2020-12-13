using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities;
using BabALSaray.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Data
{
    public class dbAccountsRepository : IdbAccountRepository
    {
        private readonly DataContext _context;
        public dbAccountsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<dbAccounts> GetDbAccountByIdAsync(int id)
        {
            return await _context.dbAccounts.FindAsync(id);
        }

        public async Task<IEnumerable<dbAccounts>> GetDbAccountsAsync()
        {
            var accountlist =  _context.dbAccounts.Include(ch => ch.Children).AsEnumerable()
             .Where(p => p.ParentId == null).AsQueryable();
            
             return await Task.FromResult(accountlist.ToList());

             
            
             
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(dbAccounts dbAccounts)
        {
            _context.Entry(dbAccounts).State = EntityState.Modified;
        }
    }
}