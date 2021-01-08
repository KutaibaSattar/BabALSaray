using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BabALSaray.Services
{
    public class TokenService : ITokenService // our interface
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;
        public TokenService(IConfiguration config, UserManager<AppUser> userManager)

        {
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

        }

        public async Task<String> CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.NameId,user.UserName)

            };

            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role,role)));
            

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();
           
            var token = tokenHandler.CreateToken(tokenDesciptor);

            return tokenHandler.WriteToken(token);

        }
    }
}