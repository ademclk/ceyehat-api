using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.Name,
            request.Surname,
            request.Email,
            request.PhoneNumber,
            request.Title,
            request.BirthDate,
            request.PassengerType,
            request.UserId);
        
        await _customerRepository.AddCustomerAsync(customer);
        
        return customer;
    }
}