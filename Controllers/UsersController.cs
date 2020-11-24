using AppEntities;
using BabALSaray.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabALSaray.Controllers
{
    
   
    public class UsersController : BaseApiController
    {
        private readonly DataContext _conetxt;
        public UsersController(DataContext conetxt)
        {
            _conetxt = conetxt;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _conetxt.Users.ToListAsync();

            return users;

            
        }
        
        [Authorize]
        // api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _conetxt.Users.FindAsync(id);

            return user;

            
        }


    }
}