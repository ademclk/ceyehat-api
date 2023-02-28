using Ceyehat.Application.Airports.Commands.CreateAirport;
using Ceyehat.Application.Common.DTOs;
using Ceyehat.Contracts.Airports;
using Ceyehat.Domain.AirportAggregate;
using Mapster;
using Microsoft.AspNetCore.SignalR;

namespace ceyehat.Common.Mapping;

public class AirportMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAirportRequest, CreateAirportCommand>();

        config.NewConfig<Airport, AirportResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CityId, src => src.CityId.Value)
            .Map(dest => dest.Timezone, src => src.TimeZone);
    }
}