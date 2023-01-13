using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Services.Authentication.Common;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;

namespace Ceyehat.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
}