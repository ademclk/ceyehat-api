using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.PriceAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class PriceRepository : IPriceRepository
{
    private readonly CeyehatDbContext _context;

    public PriceRepository(CeyehatDbContext context)
    {
        _context = context;
    }

    public async Task AddPriceAsync(Price price)
    {
        await _context.Prices.AddAsync(price);
        await _context.SaveChangesAsync();
    }
}