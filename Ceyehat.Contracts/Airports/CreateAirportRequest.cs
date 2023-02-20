namespace Ceyehat.Contracts.Airports;

public record CreateAirportRequest(
    string? Name,
    string? CityId,
    string? IataCode,
    string? IcaoCode,
    double Latitude,
    double Longitude,
    string? Timezone);