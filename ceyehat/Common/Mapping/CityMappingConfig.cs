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
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.CountryId, src => src.CountryId.Value)
            .Map(dest => dest.Districts, src => src.Districts)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);

    }
}