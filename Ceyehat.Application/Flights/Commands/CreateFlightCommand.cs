using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Flights.Commands;

public record CreateFlightCommand(
    string? FlightNumber,
    DateTime ScheduledDeparture,
    DateTime ScheduledArrival,
    FlightStatus Status,
    FlightType Type,
    DateTime? ActualDeparture,
    DateTime? ActualArrival,
    AircraftId AircraftId,
    AirportId DepartureAirportId,
    AirportId ArrivalAirportId,
    List<CreatePriceCommand> Prices
    ) : IRequest<ErrorOr<Flight>>;

public record CreatePriceCommand(
    float Value,
    Currency Currency,
    SeatClass SeatClass,
    FlightId FlightId);
    