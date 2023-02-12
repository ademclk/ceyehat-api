using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Countries;

public record CreateCountryRequest(
    string? UnLocode,
    string? Name,
    string? Iso2,
    string? Iso3,
    Currency Currency);