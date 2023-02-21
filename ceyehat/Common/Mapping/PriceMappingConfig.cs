using Ceyehat.Application.Prices.Command.CreatePrice;
using Ceyehat.Contracts.Prices;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.PriceAggregate;
using Mapster;

namespace ceyehat.Common.Mapping;

public class PriceMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePriceRequest, CreatePriceCommand>();

        config.NewConfig<Price, PriceResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Pricing, src => src.FlightPricing)
            .Map(dest => dest.Currency, src => Enum.Parse(typeof(Currency), src.Currency.ToString()));
    }
}