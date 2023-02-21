using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Application.Flights.Commands.CreateFlight;
using Ceyehat.Contracts.Flights;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class FlightMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateFlightRequest, CreateFlightCommand>();

        config.NewConfig<Flight, FlightResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AircraftId,  src => src.AircraftId.Value)
            .Map(dest => dest.Status, src => Enum.Parse(typeof(FlightStatus), src.Status.ToString()))
            .Map(dest => dest.Type, src => Enum.Parse(typeof(FlightType), src.Type.ToString()))
            .Map(dest => dest.DepartureAirportId, src => src.DepartureAirportId.Value)
            .Map(dest => dest.ArrivalAirportId, src => src.ArrivalAirportId.Value)
            .Map(dest => dest.PriceId, src => src.PriceId.Value);
    }
}