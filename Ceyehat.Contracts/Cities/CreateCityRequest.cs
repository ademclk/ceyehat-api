
using Ceyehat.Domain.CountryAggregate.ValueObjects;

namespace Ceyehat.Contracts.Cities;

public record CreateCityRequest(
    string? Name,
    CountryId CountryId,
    List<District> Districts);

public record District(
    string? Name,
    List<Neighborhood> Neighborhoods);

public record Neighborhood(
    string? Name,
    string? AirlineId,
    string? AirportId);