using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User? user);
}