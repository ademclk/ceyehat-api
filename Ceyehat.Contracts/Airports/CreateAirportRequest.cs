namespace Ceyehat.Contracts.Airports;

public record CreateAirportRequest(
    string? Name,
    string? City,
    string? IataCode,
    string? IcaoCode,
    double Latitude,
    double Longitude,
    string? Timezone);