using AppEntities;
using BabALSaray.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;

        }

        [Authorize]
     
        [HttpGet("auth")] //401 UnAuthorize Responses
        public ActionResult<string> GetSecret()
        {
                return "Secret text";
            
        }
       
         [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFount()
        {
               var thing = _context.Users.Find(-1); //not exist

               if (thing ==null) return NotFound();
                
               return Ok(thing); 

            
        }
         [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
                var thing = _context.Users.Find(-1);
               
                var thingToReturn = thing.ToString(); //null.ToString Generate error

                return thingToReturn;
              
            
        }
       
        [HttpGet("bad-request")]
       public ActionResult<string> GetBadRequest()
        {
                return BadRequest("This was not a good request");
            
        }



    }
}