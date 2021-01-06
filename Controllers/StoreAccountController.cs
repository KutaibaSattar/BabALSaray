using System.Threading.Tasks;
using BabALSaray.AppEntities.Identity;
using BabALSaray.DTOs;
using BabALSaray.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BabALSaray.Controllers
{
    public class StoreAccountController : BaseApiController
    {
        private readonly UserManager<StoreUser> _userManager;
        private readonly SignInManager<StoreUser> _signInManager;
        public StoreAccountController(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;


        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null) return Unauthorized( new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if (!result.Succeeded) return Unauthorized (new ApiResponse(401));

            return new UserDto
            {
              Token = "This will be a token",
              Username =  user.DisplayName, 

            };

        }

    }
}