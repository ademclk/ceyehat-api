namespace Ceyehat.Application.Services.Authentication;

public record AuthResult
(
    Guid Id,
    string Email,
    string Token,
    string FirstName,
    string LastName
);