using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirportAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Airports.Queries.GetAirports;

public class GetAirportsQueryHandler : IRequestHandler<GetAirportsQuery, ErrorOr<List<Airport>>>
{
    private readonly IAirportRepository _airportRepository;

    public GetAirportsQueryHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<List<Airport>>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
    {
        var airports = await _airportRepository.GetAllAirportsAsync();
        return airports;
    }
}