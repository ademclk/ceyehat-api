namespace Ceyehat.Contracts.Cities;

public record CityResponse(
    string? Id,
    string? Name,
    string? CountryId,
    List<DistrictResponse> Districts,
    DateTime CreatedAt,
    DateTime UpdatedAt);
    
public record DistrictResponse(
    string? Id,
    string? Name,
    List<NeighborhoodResponse> Neighborhoods);
    
public record NeighborhoodResponse(
    string? Id,
    string? Name,
    string? AirlineId,
    string? AirportId);