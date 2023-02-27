namespace Ceyehat.Contracts.Airports;

public record SearchAirportResponse(
    string Name,
    string IataCode,
    string City,
    string Country);