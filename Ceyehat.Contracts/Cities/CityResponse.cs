namespace Ceyehat.Contracts.Cities;

public abstract record CityResponse(
    string? Id,
    string? Name,
    string? CountryId,
    List<DistrictResponse> Districts,
    DateTime CreatedAt,
    DateTime UpdatedAt);

public abstract record DistrictResponse(
    string? Id,
    string? Name,
    List<NeighborhoodResponse> Neighborhoods);

public abstract record NeighborhoodResponse(
    string? Id,
    string? Name,
    string? AirlineId,
    string? AirportId);