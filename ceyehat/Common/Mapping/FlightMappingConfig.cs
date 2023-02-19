using Ceyehat.Application.Flights.Commands.CreateFlight;
using Ceyehat.Contracts.Flights;
using Ceyehat.Domain.FlightAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class FlightMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateFlightRequest, CreateFlightCommand>();

        config.NewConfig<Flight, FlightResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}