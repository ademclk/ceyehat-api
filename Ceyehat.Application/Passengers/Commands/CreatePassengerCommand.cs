using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Passengers.Commands;

public record CreatePassengerCommand(
    CustomerId CustomerId,
    List<CreateFlightTicketCommand> FlightTickets) : IRequest<ErrorOr<Passenger>>;
    
public record CreateFlightTicketCommand(
    FlightId FlightId,
    SeatId SeatId,
    CreateBoardingPassCommand? BoardingPass);
    
public record CreateBoardingPassCommand(
    string? Gate,
    DateTime BoardingTime);