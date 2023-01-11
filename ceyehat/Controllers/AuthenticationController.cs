using Ceyehat.Application.Common.Errors;
using Ceyehat.Application.Services.Authentication;
using Ceyehat.Application.Services.Authentication.Interfaces;
using Ceyehat.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using OneOf;

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

        var authResponse = new AuthResponse(
            authResult.User!.UserId,
            authResult.User.Email,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.Token
        );

        return Ok(authResponse);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        OneOf<AuthResult, DuplicateEmailError> registerResult = _authService.Register(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName
        );
        
        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            _ => Problem(statusCode: StatusCodes.Status409Conflict, title: "Email already exists."));
    }

    private static AuthResponse MapAuthResult(AuthResult authResult)
    {
        var authResponse = new AuthResponse(
            authResult.User!.UserId,
            authResult.User.Email,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.Token
        );
        return authResponse;
    }
}