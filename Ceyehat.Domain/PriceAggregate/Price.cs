using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.PriceAggregate.Entities;
using Ceyehat.Domain.PriceAggregate.ValueObjects;

namespace Ceyehat.Domain.PriceAggregate;

public sealed class Price : AggregateRoot<PriceId>
{
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }

    public FlightPricingId FlightPricingId { get; private set; }

    private Price(
        PriceId id,
        decimal amount,
        Currency currency,
        FlightPricingId flightPricingId)
    {
        Id = id;
        Amount = amount;
        Currency = currency;
        FlightPricingId = flightPricingId;
    }

    public static Price Create(
        decimal amount,
        Currency currency,
        FlightPricingId flightPricingId)
    {
        return new(
            PriceId.CreateUnique(),
            amount,
            currency,
            flightPricingId);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected Price()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}