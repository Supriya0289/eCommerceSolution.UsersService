using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCommerce.API.Middlewares;

    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionaHandlingMiddleware
    {
        private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionaHandlingMiddleware> _logger;

        public ExceptionaHandlingMiddleware(RequestDelegate next, ILogger<ExceptionaHandlingMiddleware> logger)
        {
            _next = next;
        _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
        try
        {
            await _next(httpContext);

        }
        catch(Exception ex)
        {
            _logger.LogError($"{ex.GetType().ToString()}: {ex.Message}");

            if(ex.InnerException is not null)
            {
                _logger.LogError($"{ex.InnerException.GetType().ToString()}: {ex.InnerException.Message}");
            }
            httpContext.Response.StatusCode = 500;
            await httpContext.Response.WriteAsJsonAsync
                (new { Message = ex.Message, Type = ex.GetType().ToString() });

        }
       

            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionaHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionaHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionaHandlingMiddleware>();
        }
    }

