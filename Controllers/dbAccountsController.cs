using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities;
using BabALSaray.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class dbAccountsController : BaseApiController
    {
        private readonly DataContext _context;
        public dbAccountsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
         public async Task<ActionResult<IEnumerable<dbAccounts>>> GetdbAccounts()
        {
           
            var dbaccounts = await  _context.Accounts.Include(ch => ch.Children).Where(p =>p.ParentId == null).ToListAsync();

            return dbaccounts;

            
        }


    }


}