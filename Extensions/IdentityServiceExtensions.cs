using System.Text;
using AppEntities.Identity;
using BabALSaray.AppEntities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BabALSaray.Extensions
{
     /* inside here we'll make this a static class because it's going to contain extension methods */
    public static class IdentityServiceExtensions
    {
        // use (this) because we need to extend IserviceCollection 
        public static IServiceCollection AddIdentityServices( this IServiceCollection services, IConfiguration config)
        {
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer( options =>{
                options.TokenValidationParameters = new TokenValidationParameters
                {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer  = false,
                        ValidateAudience = false,

                };
                

            });

           // for allowing the user manager
            var builder = services.AddIdentityCore<StoreUser>();
            builder = new IdentityBuilder(builder.UserType , builder.Services);
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();
            builder.AddSignInManager<SignInManager<StoreUser>>();

            services.AddAuthentication();

            return services;

            
        }
        
    }
}