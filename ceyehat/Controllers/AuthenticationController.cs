using Ceyehat.Application.Common.Errors;
using Ceyehat.Application.Services.Authentication;
using Ceyehat.Application.Services.Authentication.Interfaces;
using Ceyehat.Contracts.Authentication;
using FluentResults;
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
        Result<AuthResult> registerResult = _authService.Register(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName
        );
        
        if (registerResult.IsSuccess)
        {
            return Ok(MapAuthResult(registerResult.Value));
        }
        
        var firstError = registerResult.Errors.First();
        
        if (firstError is DuplicateEmailError)
        {
            return BadRequest(new {message = firstError.Message});
        }

        return Problem();
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