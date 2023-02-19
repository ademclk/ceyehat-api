using Ceyehat.Domain.Enums;
using Ceyehat.Domain.PriceAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Prices.Command.CreatePrice;

public record CreatePriceCommand(
    decimal Amount,
    Currency Currency,
    FlightPricingCommand Pricing) : IRequest<ErrorOr<Price>>;

public record FlightPricingCommand(
    decimal BaseCost,
    decimal MarkupPercentage,
    decimal DemandMultiplier,
    decimal CompetitionMultiplier,
    decimal SeasonalMultiplier,
    decimal LengthMultiplier,
    decimal ClassMultiplier
);
    