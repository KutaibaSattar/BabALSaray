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
using BabALSaray.Extensions;
using DTOs;

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
            //var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            //var user = await _userManager.FindByEmailAsync(email);

            // calling extension userManager from  UserManagerExtensions, HttpContext can reached only inside controller
           
            var user = await _userManager.FindByEmailFromClaimPrinciple(HttpContext.User); 


            var userToReturn = _mapper.Map<UserDto>(user);

            return Ok(userToReturn);

        }

        

        [Authorize]
        [HttpGetAttribute("address")]

        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
             var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
             var user = await _userManager.FindByEmailAsync(email);

              return _mapper.Map<Address,AddressDto>(user.Address)  ;
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress (AddressDto address)
        {
             var email = HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
             var user = await _userManager.FindByEmailAsync(email);

             user.Address = _mapper.Map<AddressDto,Address>(address);

             var result = await _userManager.UpdateAsync(user);

             if (result.Succeeded) return Ok(_mapper.Map<Address,AddressDto>(user.Address));

             return BadRequest ("Problem updating the user");

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

        [HttpPut]

        public async Task<ActionResult> UpdateUser(MemberDto memberDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            var user =  await _userRepository.GetUserByNameAsync(username);
           
            _mapper.Map(memberDto,user);
           
            _userRepository.Update(user);

            if (await _userRepository.SaveAllAsync()) return NoContent();
            
            return BadRequest("Faild to update user");

        }


    }
}