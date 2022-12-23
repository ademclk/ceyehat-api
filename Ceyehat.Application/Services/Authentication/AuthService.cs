using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Services.Authentication.Interfaces;

namespace Ceyehat.Application.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

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
            
        // Checking if user exists
        
        // Creating user
        
        // Creating token
        var userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, email);
        
        return new AuthResult(
            userId,
            email,
            token,
            firstName,
            lastName
        );
    }
}