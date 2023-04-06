using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Contracts.Customers;

public record AddPassengerRequest(
    string Name,
    string Surname,
    string Email,
    string PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType,
    List<AddBookingRequest> AddBookingRequests
);

public record AddBookingRequest(
    string? SeatId,
    string? FlightId,
    float Price,
    Currency Currency,
    PassengerType PassengerType
);