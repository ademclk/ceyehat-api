using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Seats;

public record CreateSeatRequest(
    string? SeatNumber,
    string? AircraftId,
    SeatClass SeatClass,
    SeatStatus SeatStatus);