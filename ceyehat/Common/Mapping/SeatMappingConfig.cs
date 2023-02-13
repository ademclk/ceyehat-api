using Ceyehat.Application.Seats.Commands;
using Ceyehat.Contracts.Seats;
using Ceyehat.Domain.SeatAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class SeatMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSeatRequest, CreateSeatCommand>();

        config.NewConfig<Seat, SeatResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}