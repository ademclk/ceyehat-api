using Ceyehat.Domain.AirlineAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAirlineRepository
{
    Task AddAirlineAsync(Airline airline);
}