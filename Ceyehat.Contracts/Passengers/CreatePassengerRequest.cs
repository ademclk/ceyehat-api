using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Contracts.Passengers;

public record CreatePassengerRequest(
    CustomerId CustomerId,
    List<CreateFlightTicketRequest> FlightTickets,
    List<CreateBoardingPassRequest> BoardingPasses) : IRequest<ErrorOr<Passenger>>;

public record CreateFlightTicketRequest(
    BookingId BookingId);

public record CreateBoardingPassRequest(
    FlightTicketId FlightTicketId,
    string? Gate,
    DateTime BoardingTime);