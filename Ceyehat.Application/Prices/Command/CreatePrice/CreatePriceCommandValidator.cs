using Ceyehat.Domain.PriceAggregate;
using FluentValidation;

namespace Ceyehat.Application.Prices.Command.CreatePrice;

public class CreatePriceCommandValidator : AbstractValidator<Price>
{
    public CreatePriceCommandValidator()
    {
        RuleFor(x => x.Amount)
            .NotEmpty();
        RuleFor(x => x.Currency)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.BaseCost)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.MarkupPercentage)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.DemandMultiplier)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.CompetitionMultiplier)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.SeasonalMultiplier)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.LengthMultiplier)
            .NotEmpty();
        RuleFor(x => x.FlightPricing.ClassMultiplier)
            .NotEmpty();
    }
}