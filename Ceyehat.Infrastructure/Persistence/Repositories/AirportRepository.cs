using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class AirportRepository : IAirportRepository
{
    private readonly CeyehatDbContext _dbContext;

    public AirportRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Airport>> GetAllAirportsAsync()
    {
        return await _dbContext.Airports.ToListAsync();
    }

    public async Task<Airport?> GetAirportByIdAsync(AirportId airportId)
    {
        return await _dbContext.Airports.FindAsync(airportId.Value);
    }

    public async Task AddAirportAsync(Airport airport)
    {
        await _dbContext.Airports.AddAsync(airport);
        await _dbContext.SaveChangesAsync();
    }
}