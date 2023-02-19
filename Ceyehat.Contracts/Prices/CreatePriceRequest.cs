using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Prices;

public record CreatePriceRequest(
    decimal Amount,
    Currency Currency,
    FlightPricingRequest Pricing);

public record FlightPricingRequest(
    decimal BaseCost,
    decimal MarkupPercentage,
    decimal DemandMultiplier,
    decimal CompetitionMultiplier,
    decimal SeasonalMultiplier,
    decimal LengthMultiplier,
    decimal ClassMultiplier
);
    