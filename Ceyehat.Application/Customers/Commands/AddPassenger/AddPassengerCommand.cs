using Ceyehat.Application.Customers.Commands.CreateCustomer;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
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
    PassengerType PassengerType,
    List<AddBookingCommand> AddBookingCommands
) : IRequest<ErrorOr<Customer>>;

public record AddBookingCommand(
    string? SeatId,
    string? FlightId,
    float Price,
    Currency Currency,
    PassengerType PassengerType
);
