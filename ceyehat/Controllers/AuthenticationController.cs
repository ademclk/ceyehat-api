using Ceyehat.Application.Services.Authentication.Interfaces;
using Ceyehat.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await _authService.Login(
            request.Email,
            request.Password
        );
        return Ok(authResult);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var authResult = await _authService.Register(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName
        );

        return Ok(authResult);
    }
}