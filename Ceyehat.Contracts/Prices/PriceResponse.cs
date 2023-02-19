using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Prices;

public record PriceResponse(
    string? Id,
    decimal Amount,
    Currency Currency,
    FlightPricing Pricing,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record FlightPricing(
    string? Id,
    decimal BaseCost,
    decimal MarkupPercentage,
    decimal DemandMultiplier,
    decimal CompetitionMultiplier,
    decimal SeasonalMultiplier,
    decimal LengthMultiplier,
    decimal ClassMultiplier,
    decimal TotalCost
);
