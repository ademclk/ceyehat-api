namespace Ceyehat.Contracts.Customers;

public record CreateTicketRequest(
    string? Email,
    string? FlightId
);