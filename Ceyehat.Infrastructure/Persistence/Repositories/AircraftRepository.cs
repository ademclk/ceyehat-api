using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class AircraftRepository : IAircraftRepository
{
    private readonly CeyehatDbContext _dbContext;

    public AircraftRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Aircraft?> GetAircraftByIdAsync(AircraftId aircraftId)
    {
        return await _dbContext.Aircrafts.FindAsync(aircraftId.Value);
    }

    public async Task AddAircraftAsync(Aircraft aircraft)
    {
        await _dbContext.Aircrafts.AddAsync(aircraft);
        await _dbContext.SaveChangesAsync();
    }
}