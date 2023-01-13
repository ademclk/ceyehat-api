using Ceyehat.Application.Services.Authentication;
using Ceyehat.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authService.Login(
            request.Email,
            request.Password
        );

        return loginResult.MatchFirst(
            authResult => Ok(MapAuthResult(authResult)),
            firstError => Problem(statusCode: StatusCodes.Status400BadRequest, title: firstError.Description )
        );
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> registerResult = _authService.Register(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName
        );

        return registerResult.MatchFirst(
            authResult => Ok(MapAuthResult(authResult)),
             firstError => Problem(statusCode: StatusCodes.Status409Conflict, title: firstError.Description)
        );
    }

    private static AuthResponse MapAuthResult(AuthenticationResult registerResult)
    {
        var authResponse = new AuthResponse(
            registerResult.User!.UserId,
            registerResult.User.Email,
            registerResult.User.FirstName,
            registerResult.User.LastName,
            registerResult.Token
        );
        return authResponse;
    }
}