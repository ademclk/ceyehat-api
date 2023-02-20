namespace Ceyehat.Contracts.Airports;

public record AirportResponse(
    string Id,
    string Name,
    string CityId,
    string IataCode,
    string IcaoCode,
    double Latitude,
    double Longitude,
    string Timezone,
    List<string> DepartureFlights,
    List<string> ArrivalFlights,
    DateTime CreatedAt,
    DateTime UpdatedAt);