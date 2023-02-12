using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirlineAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class AirlineRepository : IAirlineRepository
{
    private readonly CeyehatDbContext _dbContext;

    public AirlineRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAirlineAsync(Airline airline)
    {
        await _dbContext.Airlines.AddAsync(airline);
        await _dbContext.SaveChangesAsync();
    }
}