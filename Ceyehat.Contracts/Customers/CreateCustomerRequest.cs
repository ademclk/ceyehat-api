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
    List<BookingRequest> BookingIds);

public record BookingRequest(
    string? SeatId,
    string? FlightId);