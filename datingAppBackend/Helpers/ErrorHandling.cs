using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace YourNamespace.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Continue processing the request
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                // Customize the error response
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Create and send an error response JSON object
                var errorResponse = new
                {
                    Message = "An error occurred while processing your request.",
                    ExceptionMessage = ex.Message
                    // You can include more error details here if needed
                };

                await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(errorResponse));
            }
        }
    }
}
