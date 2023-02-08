using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CountryAggregate.ValueObjects;

namespace Ceyehat.Domain.CountryAggregate;

public sealed class Country : AggregateRoot<CountryId>
{
    private readonly List<AircraftId> _aircraftIds = new();
    private readonly List<AirlineId> _airlineIds = new();
    private readonly List<CityId> _cityIds = new();
    public string? UnLocode { get; }
    public string? Name { get; }
    public string? Iso2 { get; }
    public string? Iso3 { get; }

    public IReadOnlyList<AircraftId> AircraftIds => _aircraftIds.AsReadOnly();
    public IReadOnlyList<AirlineId> AirlineIds => _airlineIds.AsReadOnly();
    public IReadOnlyList<CityId> CityIds => _cityIds.AsReadOnly();
    
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    private Country(
        CountryId countryId,
        string? unLocode,
        string? name,
        string? iso2,
        string? iso3,
        DateTime createdAt,
        DateTime updatedAt) : base(countryId)
    {
        UnLocode = unLocode;
        Name = name;
        Iso2 = iso2;
        Iso3 = iso3;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Country Create(
        string? unLocode,
        string? name,
        string? iso2,
        string? iso3)
    {
        return new(
            CountryId.CreateUnique(),
            unLocode,
            name,
            iso2,
            iso3,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddAircraft(AircraftId aircraftId)
    {
        _aircraftIds.Add(aircraftId);
    }
    public void RemoveAircraft(AircraftId aircraftId)
    {
        _aircraftIds.Remove(aircraftId);
    }

    public void AddAirline(AirlineId airlineId)
    {
        _airlineIds.Add(airlineId);
    }
    public void RemoveAirline(AirlineId airlineId)
    {
        _airlineIds.Remove(airlineId);
    }

    public void AddCity(CityId cityId)
    {
        _cityIds.Add(cityId);
    }

    public void RemoveCity(CityId cityId)
    {
        _cityIds.Remove(cityId);
    }
}