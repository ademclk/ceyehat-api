using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Services.Authentication;

public record AuthenticationResult
(
    User? User,
    string Token
);