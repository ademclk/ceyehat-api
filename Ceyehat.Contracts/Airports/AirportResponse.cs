namespace Ceyehat.Contracts.Airports;

public record AirportResponse(
    string Id,
    string Name,
    string City,
    string Country,
    string IataCode,
    string IcaoCode,
    double Latitude,
    double Longitude,
    int Altitude,
    double Timezone,
    string Dst,
    string TzDatabaseTimezone,
    string Type,
    string Source);