using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.Entities;
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
        
        foreach (var b in request.BookingCommands)
        {
            var booking = Booking.Create(
                b.SeatId,
                b.FlightId,
                b.Price,
                b.Currency,
                b.PassengerType);
            customer.AddBooking(booking);
        }
        
        foreach (var ft in request.FlightTicketCommands)
        {
            var flightTicket = FlightTicket.Create(
                ft.BoardingPassId,
                ft.BookingId);
            customer.AddFlightTicket(flightTicket);
        }
        
        foreach (var bp in request.BoardingPassCommands)
        {
            var boardingPass = BoardingPass.Create(
                bp.BoardingGroup!,
                bp.BoardingGate!,
                bp.BoardingTime,
                bp.CheckInTime);
            customer.AddBoardingPass(boardingPass);
        }

        await _customerRepository.AddCustomerAsync(customer);

        return customer;
    }
}