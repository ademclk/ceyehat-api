namespace Ceyehat.Contracts.Flights;

public abstract record FlightResponse(
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
    string? EconomyPriceId,
    string? ComfortPriceId,
    string? BusinessPriceId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

