using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Contracts.Cities;
using Ceyehat.Domain.CityAggregate;
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
        var city = City.Create(command.CountryId, command.Name);

        foreach (var districtCommand in command.Districts)
        {
            var district = District.Create(districtCommand.Name);

            foreach (var neighborhoodCommand in districtCommand.Neighborhoods)
            {
                var neighborhood = Domain.CityAggregate.Entities.Neighborhood.Create(neighborhoodCommand.Name, neighborhoodCommand.AirlineId, neighborhoodCommand.AirportId);
                district.AddNeighborhood(neighborhood);
            }

            city.AddDistrict(district);
        }

        await _cityRepository.AddCityAsync(city);

        return city;
    }
}
