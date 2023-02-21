using Ceyehat.Application.Seats.Commands;
using Ceyehat.Application.Seats.Commands.CreateSeat;
using Ceyehat.Contracts.Seats;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.SeatAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class SeatMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateSeatRequest, CreateSeatCommand>();

        config.NewConfig<Seat, SeatResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AircraftId, src => src.AircraftId.Value)
            .Map(dest => dest.SeatStatus, src => Enum.Parse(typeof(SeatStatus), src.SeatStatus.ToString()))
            .Map(dest => dest.SeatClass, src => Enum.Parse(typeof(SeatClass), src.SeatClass.ToString()));

    }
}