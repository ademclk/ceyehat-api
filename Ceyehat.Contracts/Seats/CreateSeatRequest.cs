using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Seats;

public record CreateSeatRequest(
    string? SeatNumber,
    string? AircraftId,
    string? FlightId,
    SeatClass SeatClass,
    SeatStatus SeatStatus);