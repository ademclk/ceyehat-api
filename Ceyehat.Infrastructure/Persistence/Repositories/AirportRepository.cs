using Ceyehat.Application.Common.DTOs;
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

    public async Task<List<AirportDto>> SearchAirportsAsync(string searchTerm)
    {

        var airports = await _dbContext.Airports
            .Join(_dbContext.Cities, a => a.CityId, c => c.Id, (a, c) => new { a, c })
            .Join(_dbContext.Countries, ac => ac.c.CountryId, co => co.Id, (ac, co) => new AirportDto
            {
                Name = ac.a.Name,
                IataCode = ac.a.IataCode,
                CityName = ac.c.Name,
                CountryName = co.Name
            }).ToListAsync();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return airports;
        }

        var upperSearchTerm = searchTerm.ToUpperInvariant();
        var searchResult = airports.Where(dto => dto.Name!.ToUpperInvariant().Contains(upperSearchTerm)
                                                 || dto.IataCode!.ToUpperInvariant().Contains(upperSearchTerm)
                                                 || dto.CityName!.ToUpperInvariant().Contains(upperSearchTerm)
                                                 || dto.CountryName!.ToUpperInvariant().Contains(upperSearchTerm))
            .ToList();

        return searchResult;
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