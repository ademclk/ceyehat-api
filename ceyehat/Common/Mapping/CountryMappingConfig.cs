using Ceyehat.Contracts.Countries;
using Ceyehat.Domain.CountryAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class CountryMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCountryRequest, Country>();

        config.NewConfig<Country, CountryResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}