using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AircraftAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class AircraftRepository : IAircraftRepository
{
    private readonly CeyehatDbContext _dbContext;

    public AircraftRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAircraftAsync(Aircraft aircraft)
    {
        await _dbContext.Aircrafts.AddAsync(aircraft);
        await _dbContext.SaveChangesAsync();
    }
}