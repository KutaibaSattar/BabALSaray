using BabALSaray.Errors;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
     public class HomeController : ControllerBase
    {
      /*  public IActionResult Problem()
    {
        return StatusCode(500);
    }  */

    public IActionResult Error(int? statusCode = null)
    {
        if (statusCode.HasValue)
        {
            if (statusCode.Value == 404 || statusCode.Value == 500)
            {
              return new ObjectResult(new ApiResponse(404));
            }
        }
        return new ObjectResult(new ApiResponse(404));
    } 
   
        
    }
}