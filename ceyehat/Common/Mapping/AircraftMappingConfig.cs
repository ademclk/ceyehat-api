using Ceyehat.Application.Aircrafts.Commands.CreateAircraft;
using Ceyehat.Contracts.Aircrafts;
using Ceyehat.Domain.AircraftAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class AircraftMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAircraftRequest, CreateAircraftCommand>();

        config.NewConfig<Aircraft, AircraftResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}