using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Customers;

public record CreateCustomerRequest(
    string? Name,
    string? Surname,
    string? Email,
    string? PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType,
    string? UserId,
    List<BookingRequest> BookingIds,
    List<FlightTicketRequest> FlightTicketIds,
    List<BoardingPassRequest> BoardingPassIds);

public record BookingRequest(
    string? SeatId,
    string? FlightId,
    float Price,
    Currency Currency,
    PassengerType PassengerType);

public record FlightTicketRequest(
    string? BoardingPassId,
    string? BookingId);

public record BoardingPassRequest(
    string? BoardingGroup,
    string? BoardingGate,
    DateTime BoardingTime,
    DateTime CheckInTime
);