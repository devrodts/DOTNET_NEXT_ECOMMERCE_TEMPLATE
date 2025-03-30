using Microsoft.AspNetCore.Http; 
using System.Net;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Middleware
{
    public class GlobalException
    {
        private readonly RequestDelegate _next;

    
        public GlobalException(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string message = "Sorry, an Internal Server Error has occurred, please try again later.";
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string title = "Error";

            try
            {
                if (context.Response.StatusCode == StatusCodes.Status429TooManyRequests)
                {
                    title = "Warning guys...";
                    message = "Too many requests? Why?";
                    statusCode = StatusCodes.Status429TooManyRequests;
                }
                else if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    title = "Alert";
                    message = "You are not authorized to access.";
                    await ModifyHeader(context, title, message, statusCode);
                }
                else if (context.Response.StatusCode == StatusCodes.Status403Forbidden)
                {
                    title = "Out of Access";
                    message = "You aren't allowed to access.";
                    statusCode = StatusCodes.Status403Forbidden;
                    await ModifyHeader(context, title, message, statusCode);
                }

                // Chama o próximo middleware no pipeline
                await _next(context);
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"An error has occurred: {e}");
                LogException.LogExceptions(e);

                if (e is TaskCanceledException || e is TimeoutException)
                {
                    title = "Out of time soon";
                    message = "Request timeout... try again.";
                    statusCode = StatusCodes.Status408RequestTimeout;
                }

                await ModifyHeader(context, title, message, statusCode);
                throw; // Relança a exceção, mantendo a stack trace original
            }
        }

        private static async Task ModifyHeader(HttpContext context, string title, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            var problemDetails = new ProblemDetails
            {
                Detail = message,
                Status = statusCode,
                Title = title
            };
            await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails), CancellationToken.None);
        }
    }
}