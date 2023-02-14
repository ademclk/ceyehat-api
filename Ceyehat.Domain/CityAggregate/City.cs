using Ceyehat.Domain.CityAggregate.Entities;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
namespace Ceyehat.Domain.CityAggregate;

public sealed class City : AggregateRoot<CityId>
{
    private readonly List<District> _districts = new();
    public string? Name { get; private set; }

    public CountryId CountryId { get; private set; }
    public IReadOnlyList<District> Districts => _districts.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private City(
        CityId cityId,
        CountryId countryId,
        string? name,
        DateTime createdAt,
        DateTime updatedAt) : base(cityId)
    {
        Name = name;
        CountryId = countryId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static City Create(
        CountryId countryId,
        string? name)
    {
        return new(
            CityId.CreateUnique(),
            countryId,
            name,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddDistrict(District district)
    {
        _districts.Add(district);
    }

    public void RemoveDistrict(District district)
    {
        _districts.Remove(district);
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private City()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}