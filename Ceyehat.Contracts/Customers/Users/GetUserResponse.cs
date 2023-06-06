namespace Ceyehat.Contracts.Customers.Users;

public record GetUserResponse(
    string? Id,
    string? FirstName,
    string? LastName,
    string? Email,
    string? CustomerId
);