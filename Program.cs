using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BabALSaray.AppEntities;
using BabALSaray.AppEntities.Identity;
using BabALSaray.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BabALSaray
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();

           using var scope = host.Services.CreateScope();
           var services = scope.ServiceProvider;
                
               try
            {
               var context = services.GetRequiredService<DataContext>();
               var userManager = services.GetRequiredService<UserManager<AppUser>>();
               var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
                
                //await context.Database.MigrateAsync();
                
                await Seed.SeedUsersAsync(userManager,roleManager); 
                
            }
            catch (Exception ex)
            {
                
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            } 


        
           
           host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
