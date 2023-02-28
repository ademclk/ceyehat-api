using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.CountryAggregate.ValueObjects;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly CeyehatDbContext _dbContext;

    public CountryRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Country?> GetCountryByIdAsync(CountryId countryId)
    {
        return await _dbContext.Countries.FindAsync(countryId.Value);
    }

    public async Task AddCountryAsync(Country country)
    {
        await _dbContext.Countries.AddAsync(country);
        await _dbContext.SaveChangesAsync();
    }
}