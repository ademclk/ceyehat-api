using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string Name,
    string Surname,
    string Email,
    string PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType,
    UserId? UserId,
    List<BookingCommand> BookingCommands,
    List<FlightTicketCommand> FlightTicketCommands,
    List<BoardingPassCommand> BoardingPassCommands) : IRequest<ErrorOr<Customer>>;

public record BookingCommand(
    SeatId SeatId,
    FlightId FlightId,
    float Price,
    Currency Currency,
    PassengerType PassengerType);

public record FlightTicketCommand(
    BoardingPassId BoardingPassId,
    BookingId BookingId);

public record BoardingPassCommand(
    string? BoardingGroup,
    string? BoardingGate,
    DateTime BoardingTime,
    DateTime CheckInTime
);


