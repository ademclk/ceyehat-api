using Ceyehat.Application.Passengers.Commands;
using Ceyehat.Contracts.Passengers;
using Ceyehat.Domain.PassengerAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class PassengerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePassengerRequest, CreatePassengerCommand>();

        config.NewConfig<Passenger, PassengerResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}