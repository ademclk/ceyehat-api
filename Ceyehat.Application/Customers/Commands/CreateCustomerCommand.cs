using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Commands;

public record CreateCustomerCommand(
    string Name,
    string Surname,
    string Email,
    string PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType,
    UserId? UserId) : IRequest<ErrorOr<Customer>>;