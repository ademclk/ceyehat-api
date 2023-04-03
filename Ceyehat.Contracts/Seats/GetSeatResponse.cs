namespace Ceyehat.Contracts.Seats;

public record GetSeatResponse(
    string? SeatNumber,
    string SeatClass,
    string SeatStatus);