using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using Ceyehat.Domain.UserAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<Token>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Token>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userResponse = await _userRepository.GetUserByEmailAsync(command.Email);
        // Check if user already exists
        if (userResponse is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Creating user
        var user = new User
        {
            Email = command.Email,
            Password = command.Password,
            FirstName = command.FirstName,
            LastName = command.LastName
        };

        await _userRepository.AddUserAsync(user);

        // Creating token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }
}