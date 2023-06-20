namespace Ceyehat.Contracts.Authentication;

public abstract record AuthenticationResponse(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    string Token);