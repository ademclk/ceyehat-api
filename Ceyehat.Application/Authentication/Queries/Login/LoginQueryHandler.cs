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
        var userResponse = await _userRepository.GetUserByEmail(query.Email);
        // Validate if user exists
        if (userResponse == null)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Validate if password is correct
        if (userResponse.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        // Generate JWT token
        var token = _jwtTokenGenerator.GenerateToken(userResponse);

        return new AuthenticationResult(
            userResponse,
            token);
    }
}