namespace Ceyehat.Contracts.Cities;

public record CreateCityRequest(
    string? Name,
    string? CountryId,
    List<District> Districts);

public abstract record District(
    string? Name,
    List<Neighborhood> Neighborhoods);

public abstract record Neighborhood(
    string? Name,
    string? AirlineId,
    string? AirportId);