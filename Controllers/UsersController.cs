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

namespace BabALSaray.Controllers
{


    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;

            _userRepository = userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
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