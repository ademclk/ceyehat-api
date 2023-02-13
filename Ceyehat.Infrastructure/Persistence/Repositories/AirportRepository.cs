using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirportAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class AirportRepository : IAirportRepository
{
    private readonly CeyehatDbContext _dbContext;

    public AirportRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAirportAsync(Airport airport)
    {
        await _dbContext.Airports.AddAsync(airport);
        await _dbContext.SaveChangesAsync();
    }
}