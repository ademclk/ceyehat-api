using Ceyehat.Application.Common.DTOs;
using Ceyehat.Application.Common.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Seats.Queries.GetSeats;

public class GetSeatsQueryHandler : IRequestHandler<GetSeatsQuery, ErrorOr<List<SeatDto>>>
{
    private readonly ISeatRepository _seatRepository;

    public GetSeatsQueryHandler(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    public async Task<ErrorOr<List<SeatDto>>> Handle(GetSeatsQuery request, CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.GetSeatsAsync(request.FlightNumber!, request.AircraftName!);

        return seats;
    }
}