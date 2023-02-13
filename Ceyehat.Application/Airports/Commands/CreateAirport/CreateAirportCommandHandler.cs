using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirportAggregate;
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
        var airport = Airport.Create(
            request.Name,
            request.IataCode,
            request.IcaoCode,
            request.Latitude,
            request.Longitude,
            request.Timezone,
            request.CityId);

        await _airportRepository.AddAirportAsync(airport);

        return airport;
    }
}