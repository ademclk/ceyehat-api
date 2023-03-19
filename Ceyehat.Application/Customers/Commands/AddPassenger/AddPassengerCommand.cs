using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.Enums;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Commands.AddPassenger;
public record AddPassengerCommand(
    string Name,
    string Surname,
    string Email,
    string PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType
) : IRequest<ErrorOr<Customer>>;