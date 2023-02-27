using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.AirportAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IAirportRepository
{
    Task<List<Airport>> GetAllAirportsAsync();
    Task<Airport?> GetAirportByIdAsync(AirportId airportId);
    Task AddAirportAsync(Airport airport);
}