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
    List<PriceResponse> Prices,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record PriceResponse(
    string? Id,
    float Value,
    Currency Currency,
    SeatClass SeatClass,
    string? FlightId
);