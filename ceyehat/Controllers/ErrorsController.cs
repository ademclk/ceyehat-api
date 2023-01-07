using Ceyehat.Application.Common.Errors.Interfaces;
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
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };
        return Problem(statusCode: statusCode, title: message);
    }
}