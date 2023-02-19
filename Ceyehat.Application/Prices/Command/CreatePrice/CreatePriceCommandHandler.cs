using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.PriceAggregate;
using Ceyehat.Domain.PriceAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Prices.Command.CreatePrice;

public class CreatePriceCommandHandler : IRequestHandler<CreatePriceCommand, ErrorOr<Price>>
{
    private readonly IPriceRepository _priceRepository;

    public CreatePriceCommandHandler(IPriceRepository priceRepository)
    {
        _priceRepository = priceRepository;
    }

    public async Task<ErrorOr<Price>> Handle(CreatePriceCommand request, CancellationToken cancellationToken)
    {
        var price = Price.Create(
            request.Amount,
            request.Currency,
            FlightPricing.Create(
                request.Pricing.BaseCost,
                request.Pricing.MarkupPercentage,
                request.Pricing.DemandMultiplier,
                request.Pricing.CompetitionMultiplier,
                request.Pricing.SeasonalMultiplier,
                request.Pricing.LengthMultiplier,
                request.Pricing.ClassMultiplier));
        
        await _priceRepository.AddPriceAsync(price);
    
        return price;
    }
}