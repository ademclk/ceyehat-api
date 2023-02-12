using Ceyehat.Application.Airlines.Commands.CreateAirline;
using Ceyehat.Contracts.Airlines;
using Ceyehat.Domain.AirlineAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class AirlineMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAirlineRequest, CreateAirlineCommand>();
        
        config.NewConfig<Airline, AirlineResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}