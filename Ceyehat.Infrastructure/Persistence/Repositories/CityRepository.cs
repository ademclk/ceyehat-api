using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly CeyehatDbContext _dbContext;

    public CityRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<City?> GetCityByIdAsync(CityId cityId)
    {
        return await _dbContext.Cities.FindAsync(cityId);
    }

    public async Task AddCityAsync(City city)
    {
        await _dbContext.Cities.AddAsync(city);
        await _dbContext.SaveChangesAsync();
    }
}