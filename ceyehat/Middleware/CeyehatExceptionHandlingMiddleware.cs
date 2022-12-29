using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Middleware;

public class CeyehatExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<CeyehatExceptionHandlingMiddleware> _logger;

    public CeyehatExceptionHandlingMiddleware(
        ILogger<CeyehatExceptionHandlingMiddleware> logger) => _logger = logger;

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server error",
                Title = "Server error",
                Detail = "An error occurred while processing your request."
            };

            var json = JsonSerializer.Serialize(problem);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);
        }
    }
}