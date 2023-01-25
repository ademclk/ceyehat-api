using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[ApiController]
[Route("api/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        return Problem();
    }
}