using Ceyehat.Domain.AircraftAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAircraftRepository
{
    void Add(Aircraft aircraft);
}