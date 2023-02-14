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
    UserId? UserId,
    List<string> PassengerIds,
    List<BookingResponse> BookingIds,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public record BookingResponse(
    string? Id,
    string? SeatId,
    string? FlightId);