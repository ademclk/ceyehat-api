using Ceyehat.Application.Customers.Common;
using Ceyehat.Domain.UserAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Queries.GetUser;

public record GetUserQuery(
    string? Email) : IRequest<ErrorOr<UserDtoResponse?>>;