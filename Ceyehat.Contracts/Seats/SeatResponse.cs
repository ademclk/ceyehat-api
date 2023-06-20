namespace Ceyehat.Contracts.Seats;

public abstract record SeatResponse(
    string? Id,
    string? SeatNumber,
    string SeatClass,
    string SeatStatus,
    string? AircraftId,
    string? FlightId,
    DateTime CreatedAt,
    DateTime UpdatedAt);