using Ceyehat.Application.Authentication.Common;
using Ceyehat.Application.Common.Interfaces.Authentication;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using Ceyehat.Domain.CustomerAggregate;
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
    private readonly ICustomerRepository _customerRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, ICustomerRepository customerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Token>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userResponse = await _userRepository.GetUserByEmailAsync(command.Email);

        if (userResponse is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var customerResponse = await _customerRepository.GetCustomerByEmailAsync(command.Email);

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password,
            customerResponse?.Id ?? CustomerId.CreateUnique());

        await _userRepository.AddUserAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }
}