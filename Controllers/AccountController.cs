using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BabALSaray.AppEntities;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabALSaray.Controllers
{
    public class AccountController : BaseApiController
    {

       
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            

        }

       
       
       
        [HttpPost("register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            // because using ActionResult so we can return BadRequest

            if (await CheckEmailExistsAsync(registerDto.Email).Result.Value)
            {

            }
             return BadRequest("User Name is taken");
            
            if (await UserExists(registerDto.Username)) return BadRequest("User Name is taken");

            var user = _mapper.Map<AppUser>(registerDto);

  
            user.UserName = registerDto.Username.ToLower();
          
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
                       
           if (!roleResult.Succeeded) return BadRequest(result.Errors);

           if (!result.Succeeded) return BadRequest(result.Errors);

            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Email = user.Email

            };


        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) return Unauthorized("Invalid username");

            var result =  await _signInManager.CheckPasswordSignInAsync(user,loginDto.Password,false);
            
            if (!result.Succeeded) return Unauthorized();
            
           
            return new UserDto
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),
                Email = user.Email
                
            };

        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());


        }

        [HttpGet("emailexists")]

        public async Task<ActionResult<bool>> CheckEmailExistsAsync ([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
           
        }




    }
}