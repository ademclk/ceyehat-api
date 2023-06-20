using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Customers;

public abstract record CustomerResponse(
    string? Id,
    string? Name,
    string? Surname,
    string? Email,
    string? PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType,
    string? UserId,
    List<BookingResponse> Bookings,
    List<FlightTicketResponse> FlightTickets,
    List<BoardingPassResponse> BoardingPasses,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public abstract record BookingResponse(
    string? Id,
    string? SeatId,
    float Price,
    Currency Currency,
    PassengerType PassengerType,
    string? FlightId);

public abstract record FlightTicketResponse(
    string? Id,
    string? BoardingPassId,
    string? BookingId);

public abstract record BoardingPassResponse(
    string? Id,
    string? BoardingGroup,
    string? BoardingGate,
    DateTime BoardingTime,
    DateTime CheckInTime
);