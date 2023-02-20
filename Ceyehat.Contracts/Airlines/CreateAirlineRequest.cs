namespace Ceyehat.Contracts.Airlines;

public record CreateAirlineRequest(
    string? Name,
    string? IataCode,
    string? IcaoCode,
    string? Callsign,
    string? Code,
    string? Website,
    AirlineAddressRequest Address,
    List<string> AircraftIds);

public record AirlineAddressRequest(
    string? CityId);