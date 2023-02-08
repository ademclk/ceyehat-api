using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.Entities;

public sealed class District : Entity<DistrictId>
{
    private readonly List<Neighborhood> _neighborhoods = new();
    public string? Name { get; }
    
    public IReadOnlyList<Neighborhood> Neighborhoods => _neighborhoods.AsReadOnly();
    
    public District(
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
}