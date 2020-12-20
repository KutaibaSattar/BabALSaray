using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using BabALSaray.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BabALSaray.Middleware
{
    public class ExceptionMiddleware // on Startup class only for internal server error like null exceptions
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
         IHostEnvironment env /*Check if in developement mode*/)
        {
            _env = env;
            _logger = logger;
            _next = next;

        }

        public async Task InvokeAsync (HttpContext context)
        {
         try // we used try catch block because maybe get exception from our handling error
         {
            await _next(context); // if no exception then reuest move to next stage
         }   

          catch  (Exception ex )

          {
                _logger.LogError(ex, ex.Message); //console system
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError; // (500) interanal server error
                var response = _env.IsDevelopment()
                ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString()) //devolopement more details
                : new ApiException(context.Response.StatusCode, "Internal Server Error"); // production mode

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase}; // converting to camel case
               
                var json = JsonSerializer.Serialize(response,options);

                await context.Response.WriteAsync(json);


          }

        }



    }
}