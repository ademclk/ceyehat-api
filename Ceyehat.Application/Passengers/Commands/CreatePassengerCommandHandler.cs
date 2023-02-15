using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.PassengerAggregate;
using Ceyehat.Domain.PassengerAggregate.Entities;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Passengers.Commands;

public class CreatePassengerCommandHandler : IRequestHandler<CreatePassengerCommand, ErrorOr<Passenger>>
{
    private readonly IPassengerRepository _passengerRepository;

    public CreatePassengerCommandHandler(IPassengerRepository passengerRepository)
    {
        _passengerRepository = passengerRepository;
    }

    public async Task<ErrorOr<Passenger>> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
    {
        var passenger = Passenger.Create(request.CustomerId);
        
       var flightTickets = request.FlightTickets.Select(flightTicketCommand => FlightTicket.Create(
            flightTicketCommand.FlightId,
            flightTicketCommand.SeatId,
            flightTicketCommand.BoardingPass is null
                ? null
                : BoardingPass.Create(flightTicketCommand.BoardingPass.Gate, flightTicketCommand.BoardingPass.BoardingTime)));

        await _passengerRepository.AddPassengerAsync(passenger);

        return passenger;
    }
}