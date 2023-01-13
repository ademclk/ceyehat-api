using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Services.Authentication.Common;
using Ceyehat.Domain.Common.Errors;
using Ceyehat.Domain.Entities;
using ErrorOr;

namespace Ceyehat.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public ErrorOr<AuthenticationResult> Register(string email, string password, string firstName, string lastName)
    {
        // Check if user already exists
        var registeredUser =  _userRepository.GetUserByEmail(email);
        if (registeredUser.Result != null)
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