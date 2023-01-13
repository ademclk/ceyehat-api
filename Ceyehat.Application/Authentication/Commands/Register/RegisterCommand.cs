using Ceyehat.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : IRequest<ErrorOr<AuthenticationResult>>;