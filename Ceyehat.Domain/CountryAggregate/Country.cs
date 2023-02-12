using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using Ceyehat.Domain.Enums;

namespace Ceyehat.Domain.CountryAggregate;

public sealed class Country : AggregateRoot<CountryId>
{
    private readonly List<AircraftId> _aircraftIds = new();
    private readonly List<AirlineId> _airlineIds = new();
    private readonly List<CityId> _cityIds = new();
    public string? UnLocode { get; private set; }
    public string? Name { get; private set; }
    public string? Iso2 { get; private set; }
    public string? Iso3 { get; private set; }
    public Currency Currency { get; private set; }

    public IReadOnlyList<AircraftId> AircraftIds => _aircraftIds.AsReadOnly();
    public IReadOnlyList<AirlineId> AirlineIds => _airlineIds.AsReadOnly();
    public IReadOnlyList<CityId> CityIds => _cityIds.AsReadOnly();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Country(
        CountryId countryId,
        string? unLocode,
        string? name,
        string? iso2,
        string? iso3,
        Currency currency,
        DateTime createdAt,
        DateTime updatedAt) : base(countryId)
    {
        UnLocode = unLocode;
        Name = name;
        Iso2 = iso2;
        Iso3 = iso3;
        Currency = currency;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Country Create(
        string? unLocode,
        string? name,
        string? iso2,
        string? iso3,
        Currency currency)
    {
        return new(
            CountryId.CreateUnique(),
            unLocode,
            name,
            iso2,
            iso3,
            currency,
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
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Country()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}