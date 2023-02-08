using Ceyehat.Domain.CityAggregate.Entities;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
namespace Ceyehat.Domain.CityAggregate;

public sealed class City : AggregateRoot<CityId>
{
    private readonly List<District> _districts = new();
    public string? Name { get; }
    public CountryId CountryId { get; }
    
    public IReadOnlyList<District> Districts => _districts.AsReadOnly();
     
    public City(
        CityId cityId,
        CountryId countryId,
        string? name) : base(cityId)
    {
        Name = name;
        CountryId = countryId;
    }
    
    public static City Create(
        CountryId countryId,
        string? name)
    {
        return new(
            CityId.CreateUnique(),
            countryId,
            name);
    }
    
    public void AddDistrict(District district)
    {
        _districts.Add(district);
    }
    
    public void RemoveDistrict(District district)
    {
        _districts.Remove(district);
    }
}