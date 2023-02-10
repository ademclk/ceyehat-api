using Ceyehat.Domain.AircraftAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAircraftRepository
{
    Task AddAircraftAsync(Aircraft aircraft);
}