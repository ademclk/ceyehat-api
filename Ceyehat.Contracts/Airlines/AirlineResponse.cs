using Ceyehat.Domain.CityAggregate.ValueObjects;

namespace Ceyehat.Contracts.Airlines;

public record AirlineResponse(
    string Id,
    string? Name,
    string? IataCode,
    string? IcaoCode,
    string? Callsign,
    string? Code,
    string? Website,
    AirlineAddress Address,
    List<string> AircraftIds);

public record AirlineAddress(
    CityId City);