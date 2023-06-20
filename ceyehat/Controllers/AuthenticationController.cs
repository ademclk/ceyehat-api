using Ceyehat.Application.Authentication.Commands.Register;
using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Authentication.Queries.Login;
using Ceyehat.Application.Customers.Common;
using Ceyehat.Application.Customers.Queries.GetBooking;
using Ceyehat.Application.Customers.Queries.GetFlightTicket;
using Ceyehat.Application.Customers.Queries.GetUser;
using Ceyehat.Contracts.Authentication;
using Ceyehat.Contracts.Customers.Users;
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

    [HttpPost("user-info")]
    public async Task<IActionResult> GetUserInfoAsync(GetUserRequest request)
    {
        var query = _mapper.Map<GetUserQuery>(request);
        ErrorOr<UserDtoResponse?> result = await _mediator.Send(query);

        return result.Match(
            Ok,
            Problem);
    }

    [HttpPost("user-bookings")]
    public async Task<IActionResult> GetUserBookingsAsync(GetBookingRequest request)
    {
        var query = _mapper.Map<GetBookingQuery>(request);

        var bookings = await _mediator.Send(query);

        return bookings.Match(
            Ok,
            Problem);
    }

    [HttpPost("user-tickets")]
    public async Task<IActionResult> GetUserTicketsAsync(GetFlightTicketRequest request)
    {
        var query = _mapper.Map<GetFlightTicketQuery>(request);

        var tickets = await _mediator.Send(query);

        return tickets.Match(
            Ok,
            Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<Token> loginResult = await _mediator.Send(query);

        if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: loginResult.FirstError.Description);
        }

        return loginResult.Match(
            _ => Ok(loginResult.Value),
            Problem);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<Token> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            _ => Ok(registerResult.Value),
             Problem
        );
    }
}