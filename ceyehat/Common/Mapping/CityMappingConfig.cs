using Ceyehat.Application.Cities.Commands.CreateCity;
using Ceyehat.Contracts.Cities;
using Ceyehat.Domain.CityAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class CityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCityRequest, CreateCityCommand>();

        config.NewConfig<City, CityResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<DistrictCommand, District>();

        config.NewConfig<NeighborhoodCommand, Neighborhood>();

    }
}