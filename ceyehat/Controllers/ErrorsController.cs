using Ceyehat.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[ApiController]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "An user with this email already exists."),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };
        return Problem(statusCode: statusCode, title: message);
    }
}