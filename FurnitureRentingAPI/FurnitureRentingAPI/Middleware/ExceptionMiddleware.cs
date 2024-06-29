using System.Net;
using System.Text.Json;

namespace FurnitureRentingAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unhandled exception has occurred.");

                // Set the response status code
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    value = (object)null,
                    isSuccess = false,
                    isFailure = true,
                    error = new
                    {
                        code = context.Response.StatusCode,
                        message = ex.Message,
                    }
                };

                // Serialize error response to JSON
                var jsonResponse = JsonSerializer.Serialize(errorResponse);

                // Write the JSON response to the client
                await context.Response.WriteAsync(jsonResponse);
            }
        }
    }
}
