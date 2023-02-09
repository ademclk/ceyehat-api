using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate;
using Ceyehat.Domain.UserAggregate.ValueObjects;
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

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            CustomerId.CreateUnique());

        await _userRepository.AddUserAsync(user);

        // Creating token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }
}