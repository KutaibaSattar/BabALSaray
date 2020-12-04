using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEntities;
using AutoMapper;
using BabALSaray.Data;
using BabALSaray.Interfaces;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class dbAccountsController : BaseApiController
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        private readonly IdbAccountRepository _dbAccountRepository;

        public dbAccountsController(IMapper mapper, DataContext context, IdbAccountRepository dbAccountRepository)
        {
            _dbAccountRepository = dbAccountRepository;
            _context = context;

            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<dbAccountsDto>>> GetdbAccounts()

        {


            var dbaccountsTree = await _dbAccountRepository.GetDbAccountsAsync();

            var dbaccounts = _context.dbAccounts.Include(ch => ch.Children).AsEnumerable().Where(p => p.ParentId == null)
            .AsQueryable(); //.ToListAsync();


            //var dbaccountsTree = await Task.FromResult(dbaccounts.ToList());


            var dbaccountsToReturn = _mapper.Map<IEnumerable<dbAccountsDto>>(dbaccountsTree);

          

            return Ok(dbaccountsToReturn);

           


        }


    }


}