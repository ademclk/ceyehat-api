using Ceyehat.Contracts.Aircrafts;
using Ceyehat.Contracts.Airports;
using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Flights;

public record FlightResponse(
    string? Id,
    string? FlightNumber,
    DateTime ScheduledDeparture,
    DateTime ScheduledArrival,
    FlightStatus Status,
    FlightType Type,
    DateTime? ActualDeparture,
    DateTime? ActualArrival,
    AircraftResponse Aircraft,
    AirportResponse DepartureAirport,
    AirportResponse ArrivalAirport,
    string? PriceId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);