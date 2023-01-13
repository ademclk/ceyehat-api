using Ceyehat.Application.Authentication.Commands.Register;
using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Authentication.Queries.Login;
using Ceyehat.Contracts.Authentication;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Email, request.Password, request.FirstName, request.LastName);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);
        
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