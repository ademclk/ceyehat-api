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

        foreach (var flightTicketCommand in request.FlightTickets)
        {
            var flightTicket = FlightTicket.Create(flightTicketCommand.BookingId);
            passenger.AddFlightTicket(flightTicket);
        }

        foreach (var boardingPassCommand in request.BoardingPasses)
        {
            var boardingPass = BoardingPass.Create(
                boardingPassCommand.FlightTicketId,
                boardingPassCommand.Gate,
                boardingPassCommand.BoardingTime);
            passenger.AddBoardingPass(boardingPass);
        }

        await _passengerRepository.AddPassengerAsync(passenger);

        return passenger;
    }
}