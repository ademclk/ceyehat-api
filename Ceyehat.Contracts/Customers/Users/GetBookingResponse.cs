namespace Ceyehat.Contracts.Customers.Users;

public record GetBookingResponse(
    string? BookingId,
    string? SeatId,
    string? SeatNumber,
    string? FlightId,
    string? FlightNumber,
    string? Currency,
    float Price,
    string? PassengerType
);