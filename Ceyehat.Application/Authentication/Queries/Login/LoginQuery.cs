using Ceyehat.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<Token>>;