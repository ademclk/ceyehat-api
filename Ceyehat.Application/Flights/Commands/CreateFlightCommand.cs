using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate;
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
    AirportId ArrivalAirportId
) : IRequest<ErrorOr<Flight>>;