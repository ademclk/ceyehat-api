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

    public Task AddFlightAsync(Flight flight)
    {
        _dbContext.Flights.Add(flight);
        return _dbContext.SaveChangesAsync();
    }
}