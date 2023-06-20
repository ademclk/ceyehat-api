using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.Enums;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Commands.AddPassenger;
public abstract record AddPassengerCommand(
    string Name,
    string Surname,
    string Email,
    string PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType,
    List<AddBookingCommand> AddBookingCommands
) : IRequest<ErrorOr<Customer>>;

public abstract record AddBookingCommand(
    string? SeatId,
    string? FlightId,
    float Price,
    Currency Currency,
    PassengerType PassengerType
);
