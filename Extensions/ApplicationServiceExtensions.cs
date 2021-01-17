using System.Linq;
using BabALSaray.Data;
using BabALSaray.Errors;
using BabALSaray.Interfaces;
using BabALSaray.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BabALSaray.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection /* class to be extend*/ services,
         IConfiguration config /* for connection string*/ )
        {
             services.AddScoped<ITokenService,TokenService>();

             services.AddScoped<IUserRepository,UserRepository>();

             services.AddScoped<IdbAccountRepository, DbAccountsRepository>();

             services.AddScoped<IunitOfWork, UnitOfWork>();

             services.AddScoped<IProductRepository, ProductRepository>();

             services.AddScoped<IBasketRepository,BasketRepository>();
            
             services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddScoped<IOrderService, OrderService>();

              
              services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));

            });

           
            // bad request service onfigure error
             services.Configure<ApiBehaviorOptions>( opt =>
            {
                     opt.InvalidModelStateResponseFactory = actionContext =>
                {

                    var errors = actionContext.ModelState.Where( e => e.Value.Errors.Count > 0)
                    .SelectMany( x => x.Value.Errors)
                    .Select( x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidationErrorResponse
                    {

                        Errors = errors
                        
                    };

                    return new BadRequestObjectResult(errorResponse);

                };
            });


            return services;

        }


    }
}