using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CountryAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly CeyehatDbContext _dbContext;
    
    public CountryRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCountryAsync(Country country)
    {
        await _dbContext.Countries.AddAsync(country);
        await _dbContext.SaveChangesAsync();
    }
}