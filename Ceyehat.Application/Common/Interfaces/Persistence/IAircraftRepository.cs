using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAircraftRepository
{
    Task<Aircraft?> GetAircraftByIdAsync(AircraftId aircraftId);
    Task AddAircraftAsync(Aircraft aircraft);
}