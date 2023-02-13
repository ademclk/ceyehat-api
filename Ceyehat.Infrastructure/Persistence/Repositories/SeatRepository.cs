using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.SeatAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class SeatRepository : ISeatRepository
{
    private readonly CeyehatDbContext _dbContext;

    public SeatRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddSeatAsync(Seat seat)
    {
        await _dbContext.Seats.AddAsync(seat);
        await _dbContext.SaveChangesAsync();
    }
}