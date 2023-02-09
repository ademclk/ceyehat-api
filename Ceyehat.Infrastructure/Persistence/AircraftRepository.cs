using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate;

namespace Ceyehat.Infrastructure.Persistence;

public class AircraftRepository : IAircraftRepository
{
    private static readonly List<Aircraft> _aircrafts = new();
    public void Add(Aircraft aircraft)
    {
        _aircrafts.Add(aircraft);
    }
}