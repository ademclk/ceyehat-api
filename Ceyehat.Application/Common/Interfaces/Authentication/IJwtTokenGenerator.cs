using Ceyehat.Contracts.Authentication;
using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    Token GenerateToken(User? user);
}