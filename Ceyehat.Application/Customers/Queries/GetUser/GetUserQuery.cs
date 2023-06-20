using Ceyehat.Application.Customers.Common;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Queries.GetUser;

public abstract record GetUserQuery(
    string? Email) : IRequest<ErrorOr<UserDtoResponse?>>;