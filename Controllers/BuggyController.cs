using BabALSaray.AppEntities;
using BabALSaray.Data;
using BabALSaray.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
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
        public ActionResult GetNotFount()
        {
               var thing = _context.Products.Find(-1); //not exist

               if (thing ==null) 
               {
                    return NotFound(new ApiResponse(404));
               }
           
                
               return Ok(thing); // sure not reached here

            
        }
         [HttpGet("server-error")] // internal server error 500
        public ActionResult GetServerError()
        {
                var thing = _context.Users.Find(-1);
               
                var thingToReturn = thing.ToString(); //null.ToString Generate error // we generate error

                return Ok(); // sure not reached here
              
            
        }
       
        [HttpGet("bad-request")]
       public ActionResult GetBadRequest()
        {
                return BadRequest("this was not bad request"); //(new ApiResponse(400));
            
        }

        
         [HttpGet("bad-request/{id}")] // Validation Error passing string instead of integer
       public ActionResult GetBadRequest(int id)
        {
             return Ok();   
            
        }



    }
}