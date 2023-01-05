using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[ApiController]
[Route("/error")]
public class ErrorsController : ControllerBase
{
    public IActionResult Error()
    {
        return Problem();
    }
}