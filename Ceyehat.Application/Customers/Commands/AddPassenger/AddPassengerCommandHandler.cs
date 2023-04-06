using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.Entities;
using Ceyehat.Domain.SeatAggregate;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Customers.Commands.AddPassenger;

public class AddPassengerCommandHandler : IRequestHandler<AddPassengerCommand, ErrorOr<Customer>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ISeatRepository _seatRepository;
    private readonly IFlightRepository _flightRepository;

    public AddPassengerCommandHandler(ICustomerRepository customerRepository, ISeatRepository seatRepository, IFlightRepository flightRepository)
    {
        _customerRepository = customerRepository;
        _seatRepository = seatRepository;
        _flightRepository = flightRepository;
    }

    public async Task<ErrorOr<Customer>> Handle(AddPassengerCommand request, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.GetCustomerByEmailAsync(request.Email);
        
        
        
        if (existingCustomer != null)
        {
            foreach (var bookingCommand in request.AddBookingCommands)
            {
                var flightId = await _flightRepository.GetFlightIdByFlightNumberAsync(bookingCommand.FlightId!);

                if (bookingCommand.SeatId == null)
                {
                    var booking = Booking.CreateWithoutSeat(
                        flightId!,
                        bookingCommand.Price,
                        bookingCommand.Currency,
                        bookingCommand.PassengerType);
                    
                    existingCustomer.AddBooking(booking);
                }
                
                var seatId = await _seatRepository.GetSeatIdByFlightIdAndSeatNumberAsync(flightId!, bookingCommand.SeatId!);

                var bookingWithSeat = Booking.Create(
                    seatId,
                    flightId!,
                    bookingCommand.Price,
                    bookingCommand.Currency,
                    bookingCommand.PassengerType);
                
                existingCustomer.AddBooking(bookingWithSeat);
            }
            
            await _customerRepository.UpdateCustomerAsync(existingCustomer);
            
            return existingCustomer;
        }
        
        var newCustomer = Customer.Create(
            request.Name,
            request.Surname,
            request.Email,
            request.PhoneNumber,
            request.Title,
            request.BirthDate,
            request.PassengerType,
            UserId.CreateUnique());

        foreach (var bookingCommand in request.AddBookingCommands)
        {
            var flightId = await _flightRepository.GetFlightIdByFlightNumberAsync(bookingCommand.FlightId!);
            
            if (bookingCommand.SeatId == null)
            {
                var booking = Booking.CreateWithoutSeat(
                    flightId!,
                    bookingCommand.Price,
                    bookingCommand.Currency,
                    bookingCommand.PassengerType);
                
                newCustomer.AddBooking(booking);
            }
            
            var seatId = await _seatRepository.GetSeatIdByFlightIdAndSeatNumberAsync(flightId!, bookingCommand.SeatId!);
            
            var bookingWithSeat = Booking.Create(
                seatId,
                flightId!,
                bookingCommand.Price,
                bookingCommand.Currency,
                bookingCommand.PassengerType);
            
            newCustomer.AddBooking(bookingWithSeat);
        }

        await _customerRepository.AddCustomerAsync(newCustomer);

        return newCustomer;
    }
}