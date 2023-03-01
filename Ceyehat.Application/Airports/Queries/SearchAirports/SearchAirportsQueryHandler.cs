using Ceyehat.Application.Common.DTOs;
using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirportAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Airports.Queries.SearchAirports;

public class SearchAirportsQueryHandler : IRequestHandler<SearchAirportsQuery, ErrorOr<List<AirportDto>>>
{
    private readonly IAirportRepository _airportRepository;

    public SearchAirportsQueryHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<List<AirportDto>>> Handle(SearchAirportsQuery request, CancellationToken cancellationToken)
    {
        var airportDtos = await _airportRepository.SearchAirportsAsync(request.SearchTerm!);

        return airportDtos;
    }
}