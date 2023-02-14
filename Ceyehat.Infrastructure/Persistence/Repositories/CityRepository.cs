using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CityAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly CeyehatDbContext _dbContext;

    public CityRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCityAsync(City city)
    {
        await _dbContext.Cities.AddAsync(city);
        await _dbContext.SaveChangesAsync();
    }
}