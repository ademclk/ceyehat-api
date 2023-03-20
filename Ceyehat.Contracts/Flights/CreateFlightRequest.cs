using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Flights;

public record CreateFlightRequest(
    string? FlightNumber,
    DateTime ScheduledDeparture,
    DateTime ScheduledArrival,
    FlightStatus Status,
    FlightType Type,
    DateTime? ActualDeparture,
    DateTime? ActualArrival,
    string? AircraftId,
    string? DepartureAirportId,
    string? ArrivalAirportId,
    string? EconomyPriceId,
    string? ComfortPriceId,
    string? BusinessPriceId
);
