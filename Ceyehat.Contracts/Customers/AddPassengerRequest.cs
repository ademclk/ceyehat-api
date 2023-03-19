using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Customers;

public record AddPassengerRequest(
    string Name,
    string Surname,
    string Email,
    string PhoneNumber,
    Title Title,
    DateTime BirthDate,
    PassengerType PassengerType
);