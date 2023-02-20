using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Contracts.Cities;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using District = Ceyehat.Domain.CityAggregate.Entities.District;

namespace Ceyehat.Application.Cities.Commands.CreateCity;

public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, ErrorOr<City>>
{
    private readonly ICityRepository _cityRepository;

    public CreateCityCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<City>> Handle(CreateCityCommand command, CancellationToken cancellationToken)
    {
        var countryId = CountryId.Create(Guid.Parse(command.CountryId!));

        var city = City.Create(countryId, command.Name);

        foreach (var districtCommand in command.Districts)
        {
            var district = District.Create(districtCommand.Name);

            foreach (var neighborhoodCommand in districtCommand.Neighborhoods)
            {
                if (neighborhoodCommand.AirlineId is not null && neighborhoodCommand.AirportId is not null)
                {
                    var airlineId = AirlineId.Create(Guid.Parse(neighborhoodCommand.AirlineId));
                    var airportId = AirportId.Create(Guid.Parse(neighborhoodCommand.AirportId));
                    var neighborhood1 = Domain.CityAggregate.Entities.Neighborhood.Create(neighborhoodCommand.Name, airlineId, airportId);
                    district.AddNeighborhood(neighborhood1);
                    continue;
                }

                var neighborhood = Domain.CityAggregate.Entities.Neighborhood.CreateWithout(neighborhoodCommand.Name);
                district.AddNeighborhood(neighborhood);
            }

            city.AddDistrict(district);
        }

        await _cityRepository.AddCityAsync(city);

        return city;
    }
}
