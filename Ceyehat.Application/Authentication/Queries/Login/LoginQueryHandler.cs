using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Authentication.Queries.Login;

public class LoginQueryHandler : 
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Validate if user exists
        var user = _userRepository.GetUserByEmail(query.Email);
        
        if (user.Result == null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Validate if password is correct
        if (user.Result!.Password != query.Password)
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