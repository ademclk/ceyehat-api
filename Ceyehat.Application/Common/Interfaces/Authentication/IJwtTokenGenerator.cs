using Ceyehat.Application.Authentication.Common;
using Ceyehat.Domain.UserAggregate;

namespace Ceyehat.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    Token GenerateToken(User? user);
}