using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Seats.Commands.CreateSeat;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, ErrorOr<Seat>>
{
    private readonly ISeatRepository _seatRepository;

    public CreateSeatCommandHandler(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    public async Task<ErrorOr<Seat>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        var aircraftId = AircraftId.Create(Guid.Parse(request.AircraftId!));
        var flightId = FlightId.Create(Guid.Parse(request.FlightId!));

        var seat = Seat.Create(
            request.SeatNumber,
            request.SeatClass,
            request.SeatStatus,
            aircraftId,
            flightId);

        await _seatRepository.AddSeatAsync(seat);

        return seat;
    }
}