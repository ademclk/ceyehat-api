using Ceyehat.Application.Authentication.Commands.Register;
using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Authentication.Queries.Login;
using Ceyehat.Contracts.Authentication;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ceyehat.Controllers;

[Route("api/auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(query);

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
             errors => Problem(errors)
        );
    }
}