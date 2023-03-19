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

        var airports = await (
            from airport in _dbContext.Airports
            join city in _dbContext.Cities on airport.CityId equals city.Id
            join country in _dbContext.Countries on city.CountryId equals country.Id
            select new AirportDto
            {
                Name = airport.Name,
                IataCode = airport.IataCode,
                CityName = city.Name,
                CountryName = country.Name
            }
        ).ToListAsync();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return airports;
        }

        var lowerSearchTerm = searchTerm.ToLower();

        var searchResult = (
            from dto in airports
            where dto.Name!.ToLower().Contains(lowerSearchTerm)
                  || dto.IataCode!.ToLower().Contains(lowerSearchTerm)
                  || dto.CityName!.ToLower().Contains(lowerSearchTerm)
                  || dto.CountryName!.ToLower().Contains(lowerSearchTerm)
            select dto
        ).ToList();

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