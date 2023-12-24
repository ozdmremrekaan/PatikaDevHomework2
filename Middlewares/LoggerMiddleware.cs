using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace PatikaAkbank.NETCohorts_Homework1.Middlewares
{

    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerMiddleware> _logger;

        public LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Global loglama işlemleri
            _logger.LogInformation($"Request to {context.Request.Path}");

            await _next(context);
        }
    }
}
