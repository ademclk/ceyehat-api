using Ceyehat.Application.Cities.Commands.CreateCity;
using Ceyehat.Contracts.Cities;
using Ceyehat.Domain.CityAggregate;
using Mapster;
using District = Ceyehat.Domain.CityAggregate.Entities.District;
using Neighborhood = Ceyehat.Domain.CityAggregate.Entities.Neighborhood;

namespace ceyehat.Common.Mapping;

public class CityMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCityRequest, CreateCityCommand>();

        config.NewConfig<City, CityResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CountryId, src => src.CountryId.Value);

        config.NewConfig<Neighborhood, NeighborhoodResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<District, DistrictResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

    }
}