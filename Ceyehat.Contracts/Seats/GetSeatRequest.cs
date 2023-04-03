namespace Ceyehat.Contracts.Seats;

public record GetSeatRequest(
    string? AircraftName,
    string? FlightNumber);