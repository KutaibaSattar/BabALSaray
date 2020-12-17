using BabALSaray.Data;
using BabALSaray.Interfaces;
using BabALSaray.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BabALSaray.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config )
        {
             services.AddScoped<ITokenService,TokenService>();

             services.AddScoped<IUserRepository,UserRepository>();

             services.AddScoped<IdbAccountRepository, DbAccountsRepository>();

             services.AddScoped<IProductRepository, ProductRepository>();
              
              services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));

            });

            return services;

        }


    }
}