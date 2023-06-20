namespace Ceyehat.Contracts.Airlines;

public abstract record AirlineResponse(
    string Id,
    string? Name,
    string? IataCode,
    string? IcaoCode,
    string? Callsign,
    string? Code,
    string? Website,
    AirlineAddressResponse Address,
    List<string> AircraftIds,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public abstract record AirlineAddressResponse(
    string? City);