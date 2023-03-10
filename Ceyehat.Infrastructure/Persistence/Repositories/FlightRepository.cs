using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.FlightAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class FlightRepository : IFlightRepository
{
    private readonly CeyehatDbContext _dbContext;

    public FlightRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddFlightAsync(Flight flight)
    {
        await _dbContext.Flights.AddAsync(flight);
        await _dbContext.SaveChangesAsync();
    }
}