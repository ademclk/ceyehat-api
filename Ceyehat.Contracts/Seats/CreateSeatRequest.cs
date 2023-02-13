using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Seats;

public record CreateSeatRequest(
    string? SeatNumber,
    SeatClass SeatClass,
    SeatStatus SeatStatus);