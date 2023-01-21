namespace Ceyehat.Contracts.Authentication;

public record AuthenticationResponse(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    string Token);