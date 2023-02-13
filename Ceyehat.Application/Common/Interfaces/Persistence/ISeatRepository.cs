using Ceyehat.Domain.SeatAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ISeatRepository
{
    Task AddSeatAsync(Seat seat);
}