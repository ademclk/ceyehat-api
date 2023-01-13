using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
