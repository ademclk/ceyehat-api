using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Prices;

public record PriceResponse(
    string? Id,
    decimal Amount,
    string? Currency,
    FlightPricing Pricing,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

public record FlightPricing(
    decimal BaseCost,
    decimal MarkupPercentage,
    decimal DemandMultiplier,
    decimal CompetitionMultiplier,
    decimal SeasonalMultiplier,
    decimal LengthMultiplier,
    decimal ClassMultiplier,
    decimal TotalCost
);
