using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Services.Authentication;

public record AuthResult
(
    User User,
    string Token
);