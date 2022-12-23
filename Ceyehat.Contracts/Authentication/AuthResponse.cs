namespace Ceyehat.Contracts.Authentication;

public record AuthResponse
(
    Guid Id,
    string Email,
    string Token,
    string FirstName,
    string LastName
);