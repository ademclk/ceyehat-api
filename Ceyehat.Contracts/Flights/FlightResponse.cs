using Ceyehat.Contracts.Aircrafts;
using Ceyehat.Contracts.Airports;
using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Flights;

public record FlightResponse(
    string? Id,
    string? FlightNumber,
    DateTime ScheduledDeparture,
    DateTime ScheduledArrival,
    string? Status,
    string? Type,
    DateTime? ActualDeparture,
    DateTime? ActualArrival,
    string? AircraftId,
    string? DepartureAirportId,
    string ArrivalAirportId,
    string? PriceId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

