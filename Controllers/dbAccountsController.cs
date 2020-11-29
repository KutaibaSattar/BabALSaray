using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities;
using AutoMapper;
using BabALSaray.Data;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class dbAccountsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public dbAccountsController(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<dbAccountsDto>>> GetdbAccounts()
        
        {

           
          
           
            var dbaccounts = _context.Accounts.Include(ch => ch.Children).AsEnumerable().Where(p => p.ParentId == null)
            .AsQueryable(); //.ToListAsync();


            var dbaccountsTree = await Task.FromResult(dbaccounts.ToList());
            
            
            var dbaccountsToReturn = _mapper.Map<IEnumerable<dbAccountsDto>>(dbaccountsTree);
           
           
            //return Table .Include(x => x.Children) .AsEnumerable().Where(x => x.Parent == null).ToList();

          return Ok(dbaccountsToReturn);

           /*  var tmp = await dbaccounts.ToListAsync();

            return Ok(await dbaccounts.ToListAsync()); 
           
           
           
            return Ok(dbaccounts) ; */


            


        }


    }


}