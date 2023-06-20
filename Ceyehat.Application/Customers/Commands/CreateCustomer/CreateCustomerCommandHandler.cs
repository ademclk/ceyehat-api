using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserRepository _userRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUserRepository userRepository)
    {
        _customerRepository = customerRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var userId = await _userRepository.GetUserIdByEmailAsync(request.Email);

        var customer = Customer.Create(
            request.Name,
            request.Surname,
            request.Email,
            request.PhoneNumber,
            request.Title,
            request.BirthDate,
            request.PassengerType,
            userId ?? UserId.CreateUnique());

        await _customerRepository.AddCustomerAsync(customer);

        return customer;
    }
}