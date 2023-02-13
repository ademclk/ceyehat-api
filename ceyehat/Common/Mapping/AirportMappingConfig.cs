using Ceyehat.Application.Airports.Commands.CreateAirport;
using Ceyehat.Contracts.Airports;
using Ceyehat.Domain.AirportAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class AirportMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAirportRequest, CreateAirportCommand>();

        config.NewConfig<Airport, AirportResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}