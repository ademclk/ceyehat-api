using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Passengers.Commands;

public record CreatePassengerCommand(
    CustomerId CustomerId,
    List<CreateFlightTicketCommand> FlightTickets,
    List<CreateBoardingPassCommand> BoardingPasses) : IRequest<ErrorOr<Passenger>>;

public record CreateFlightTicketCommand(
    BookingId BookingId);

public record CreateBoardingPassCommand(
    FlightTicketId FlightTicketId,
    string? Gate,
    DateTime BoardingTime);