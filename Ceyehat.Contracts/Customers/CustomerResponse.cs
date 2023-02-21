using Ceyehat.Domain.Enums;
using Ceyehat.Domain.UserAggregate.ValueObjects;

namespace Ceyehat.Contracts.Customers;

public record CustomerResponse(
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

public record BookingResponse(
    string? Id,
    string? SeatId,
    float Price,
    Currency Currency,
    PassengerType PassengerType,
    string? FlightId);

public record FlightTicketResponse(
    string? Id,
    string? BoardingPassId,
    string? BookingId);

public record BoardingPassResponse(
    string? Id,
    string? BoardingGroup,
    string? BoardingGate,
    DateTime BoardingTime,
    DateTime CheckInTime
);