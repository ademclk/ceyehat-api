using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.Entities;

public sealed class Neighborhood : Entity<NeighborhoodId>
{
    public string? Name { get; }
    
    public AirlineId? AirlineId { get; }
    public AirportId? AirportId { get; }
    
    public Neighborhood(
        NeighborhoodId neighborhoodId,
        string? name,
        AirlineId? airlineId,
        AirportId? airportId) : base(neighborhoodId)
    {
        Name = name;
        AirlineId = airlineId;
        AirportId = airportId;
    }
    
    public static Neighborhood Create(
        string? name,
        AirlineId? airlineId,
        AirportId? airportId)
    {
        return new(
            NeighborhoodId.CreateUnique(),
            name,
            airlineId,
            airportId);
    }
}