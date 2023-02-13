using Ceyehat.Domain.AirportAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAirportRepository
{
    Task AddAirportAsync(Airport airport);
}