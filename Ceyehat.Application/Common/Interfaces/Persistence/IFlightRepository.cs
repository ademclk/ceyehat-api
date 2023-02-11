using Ceyehat.Domain.FlightAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IFlightRepository
{
    Task AddFlightAsync(Flight flight);
}