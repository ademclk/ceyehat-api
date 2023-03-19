using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Commands.AddPassenger;

public class AddPassengerCommandHandler : IRequestHandler<AddPassengerCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public AddPassengerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(AddPassengerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.Name,
            request.Surname,
            request.Email,
            request.PhoneNumber,
            request.Title,
            request.BirthDate,
            request.PassengerType,
            UserId.CreateUnique());

        await _customerRepository.AddCustomerAsync(customer);
        
        return customer;
    }
}