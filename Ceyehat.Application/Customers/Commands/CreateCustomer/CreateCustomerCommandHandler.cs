using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.Entities;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId ?? UserId.CreateUnique();

        var customer = Customer.Create(
            request.Name,
            request.Surname,
            request.Email,
            request.PhoneNumber,
            request.Title,
            request.BirthDate,
            request.PassengerType,
            userId);

        await _customerRepository.AddCustomerAsync(customer);

        return customer;
    }
}