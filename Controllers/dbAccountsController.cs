using System.Collections.Generic;
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
            var dbaccounts = await _context.Accounts.ToListAsync();

            return dbaccounts;

            
        }


    }


}