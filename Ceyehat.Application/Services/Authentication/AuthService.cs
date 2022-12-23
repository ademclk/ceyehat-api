using Ceyehat.Application.Services.Authentication.Interfaces;

namespace Ceyehat.Application.Services.Authentication;

public class AuthService : IAuthService
{
    public AuthResult Login(string email, string password)
    {
        return new AuthResult(
            Guid.NewGuid(),
            email,
            "token",
            "firstName",
            "lastName"
        );
    }

    public AuthResult Register(string email, string password, string firstName, string lastName)
    {
        return new AuthResult(
           Guid.NewGuid(),
           email,
           "token",
           firstName,
           lastName
        );
    }
}