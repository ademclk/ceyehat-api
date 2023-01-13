using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Services.Authentication.Common;
public record AuthenticationResult
(
    User? User,
    string Token
);