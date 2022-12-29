using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Services.Authentication.Interfaces;
using Ceyehat.Domain.Entities;

namespace Ceyehat.Application.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthResult Login(string email, string password)
    {
        // 1. Validate user exists
        if (_userRepository.GetUserByEmail(email) is not { } user)
        {
            throw new Exception("User with this email does not exist.");
        }

        // 2. Validate password
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // 3. Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token
        );
    }

    public AuthResult Register(string email, string password, string firstName, string lastName)
    {
        // Checking if user exists
        if (_userRepository.GetUserByEmail(email) != null)
        {
            throw new Exception("User already exists.");
        }

        // Creating user
        var user = new User
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };

        _userRepository.Add(user);

        // Creating token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token
        );
    }
}