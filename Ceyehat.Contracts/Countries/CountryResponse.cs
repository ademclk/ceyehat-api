using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Countries;

public record CountryResponse(
    string Id,
    string? UnLocode,
    string? Name,
    string? Iso2,
    string? Iso3,
    Currency Currency,
    List<string> AircraftIds,
    List<string> AirlineIds,
    List<string> CityIds,
    DateTime CreatedAt,
    DateTime UpdatedAt);