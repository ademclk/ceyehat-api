using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/[controller]")]
public class AircraftsController : ApiController
{
    [HttpGet]
    public IActionResult ListAircrafts()
    {
        return Ok(Array.Empty<string>());
    }
}