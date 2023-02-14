using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.Entities;

public sealed class District : Entity<DistrictId>
{
    private readonly List<Neighborhood> _neighborhoods = new();
    public string? Name { get; private set; }

    public IReadOnlyList<Neighborhood> Neighborhoods => _neighborhoods.AsReadOnly();

    private District(
        DistrictId districtId,
        string? name) : base(districtId)
    {
        Name = name;
    }

    public static District Create(
        string? name)
    {
        return new(
            DistrictId.CreateUnique(),
            name);
    }

    public void AddNeighborhood(Neighborhood neighborhood)
    {
        _neighborhoods.Add(neighborhood);
    }

    public void RemoveNeighborhood(Neighborhood neighborhood)
    {
        _neighborhoods.Remove(neighborhood);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private District()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}