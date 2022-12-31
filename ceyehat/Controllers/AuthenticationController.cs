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
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(
            request.Email,
            request.Password
        );

        var authResponse = new AuthResponse(
            authResult.Result.User.UserId,
            authResult.Result.User.Email,
            authResult.Result.User.FirstName,
            authResult.Result.User.LastName,
            authResult.Result.Token
        );

        return Ok(authResponse);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authService.Register(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName
        );

        var authResponse = new AuthResponse(
            authResult.Result.User.UserId,
            authResult.Result.User.Email,
            authResult.Result.User.FirstName,
            authResult.Result.User.LastName,
            authResult.Result.Token
        );

        return Ok(authResponse);
    }
}