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

    public async Task<AuthResult> Login(string email, string password)
    {
        // 1. Validate user exists
        var user = await _userRepository.GetUserByEmail(email);

        if (user == null)
        {
            throw new Exception("User with this email does not exist");
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

    public async Task<AuthResult> Register(string email, string password, string firstName, string lastName)
    {
        // Check if user already exists
        var registeredUser = await _userRepository.GetUserByEmail(email);
        if (registeredUser != null)
        {
            throw new Exception("An user with this email already exists.");
        }

        // Creating user
        var user = new User
        {
            Email = email,
            Password = password,
            FirstName = firstName,
            LastName = lastName
        };

        await _userRepository.Add(user);

        // Creating token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResult(
            user,
            token
        );
    }
}