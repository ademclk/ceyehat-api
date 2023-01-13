using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using Ceyehat.Domain.Entities;
using ErrorOr;

namespace Ceyehat.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        // Validate if user exists
        var user = _userRepository.GetUserByEmail(email);
        
        if (user.Result == null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Validate if password is correct
        if (user.Result!.Password != password)
        { 
            return Errors.Authentication.InvalidCredentials;
        }
        
        // Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(user.Result!);

        return new AuthenticationResult(
            user.Result!,
            token);
    }

    public ErrorOr<AuthenticationResult> Register(string email, string password, string firstName, string lastName)
    {
        // Check if user already exists
        var registeredUser =  _userRepository.GetUserByEmail(email);
        if (registeredUser != null)
        {
            return Errors.User.DuplicateEmail;
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

        return new AuthenticationResult(
            user,
            token
        );
    }
}