using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<Token>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Token>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        var userResponse = await _userRepository.GetUserByEmailAsync(query.Email);
        
        if (userResponse == null)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        if (userResponse.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        
        var token = _jwtTokenGenerator.GenerateToken(userResponse);

        return token;
    }
}