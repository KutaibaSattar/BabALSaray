using BabALSaray.AppEntities;
using AutoMapper;
using BabALSaray.Data;
using BabALSaray.DTOs;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BabALSaray.Controllers
{


    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(IUserRepository userRepository, IMapper mapper, SignInManager<AppUser>
        signInManager, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [Authorize]
        [HttpGet("getcurrentuser")]

        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            //var user = await _userManager.FindByNameAsync(email);
            
            var user = await _userManager.FindByEmailAsync(email);
            var userToReturn = _mapper.Map<UserDto>(user);

            return Ok(userToReturn);

        }

        [HttpGet("emailexists")]

        public async Task<ActionResult<bool>> CheckEmailExistsAsync ([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
           
        }

        [Authorize]
        [HttpGetAttribute("address")]

        public async Task<ActionResult<Address>> GetUserAddress()
        {
             var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
             var user = await _userManager.FindByEmailAsync(email);

              return user.Address  ;
        }


        [HttpGet]
        //[AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _userRepository.GetMembersAsync();

            return Ok(users);


        }

        [Authorize]
        // api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            var userToReturn = _mapper.Map<MemberDto>(user);

            return Ok(userToReturn);


        }


    }
}