using Ceyehat.Application.Services.Authentication;
using Ceyehat.Contracts.Authentication;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
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

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized, 
                title: loginResult.FirstError.Description);
        }
        
        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
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

        return registerResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
             errors => Problem(errors)
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