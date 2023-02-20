using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Airports.Commands.CreateAirport;

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, ErrorOr<Airport>>
{
    private readonly IAirportRepository _airportRepository;

    public CreateAirportCommandHandler(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task<ErrorOr<Airport>> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var cityId = CityId.Create(Guid.Parse(request.CityId!));
        
        var airport = Airport.Create(
            request.IataCode,
            request.IcaoCode,
            request.Name,
            request.Latitude,
            request.Longitude,
            request.Timezone,
            cityId);

        await _airportRepository.AddAirportAsync(airport);

        return airport;
    }
}