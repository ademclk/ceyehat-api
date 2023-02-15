using Ceyehat.Domain.PassengerAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IPassengerRepository
{
    Task AddPassengerAsync(Passenger passenger);
}