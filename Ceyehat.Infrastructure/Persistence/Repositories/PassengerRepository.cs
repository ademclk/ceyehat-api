using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.PassengerAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class PassengerRepository : IPassengerRepository
{
    private readonly CeyehatDbContext _dbContext;

    public PassengerRepository(CeyehatDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddPassengerAsync(Passenger passenger)
    {
        await _dbContext.Passengers.AddAsync(passenger);
        await _dbContext.SaveChangesAsync();
    }
}