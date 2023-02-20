using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.Entities;

public sealed class Neighborhood : Entity<NeighborhoodId>
{
    public string? Name { get; private set; }

    public AirlineId? AirlineId { get; private set; }
    public AirportId? AirportId { get; private set; }

    private Neighborhood(
        NeighborhoodId neighborhoodId,
        string? name,
        AirlineId? airlineId,
        AirportId? airportId) : base(neighborhoodId)
    {
        Name = name;
        AirlineId = airlineId;
        AirportId = airportId;
    }

    private Neighborhood(
        NeighborhoodId neighborhoodId,
        string? name) : base(neighborhoodId)
    {
        Name = name;
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

    public static Neighborhood CreateWithout(
        string? name)
    {
        return new Neighborhood(
            NeighborhoodId.CreateUnique(),
            name);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Neighborhood()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}