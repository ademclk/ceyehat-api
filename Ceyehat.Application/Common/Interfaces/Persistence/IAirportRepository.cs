using Ceyehat.Application.Common.DTOs;
using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.AirportAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAirportRepository
{
    Task<List<AirportDto>> SearchAirportsAsync(string? searchTerm);
    Task<List<Airport>> GetAllAirportsAsync();
    Task<Airport?> GetAirportByIdAsync(AirportId airportId);
    Task<AirportDto?> GetAirportByIdStringAsync(string airportId);
    Task AddAirportAsync(Airport airport);
}