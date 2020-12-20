using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{

    [ApiController] // Hendle all error of API otherwise only resturn (1) dummy
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {

    }
}