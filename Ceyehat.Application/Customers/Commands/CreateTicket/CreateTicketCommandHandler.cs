using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Customers.Commands.CreateTicket;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IFlightRepository _flightRepository;

    public CreateTicketCommandHandler(ICustomerRepository customerRepository, IFlightRepository flightRepository)
    {
        _customerRepository = customerRepository;
        _flightRepository = flightRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var flightId = await _flightRepository.GetFlightIdByFlightNumberAsync(request.FlightId!);
        var customer = await _customerRepository.GetCustomerByEmailAsync(request.Email!);

        var bookingId = customer!.Bookings!.FirstOrDefault(x => x.FlightId! == flightId!)?.Id;

        var flightTicket = FlightTicket.Create(
            null,
            bookingId!);

        customer!.AddFlightTicket(flightTicket);

        await _customerRepository.UpdateCustomerAsync(customer);

        return customer;
    }
}