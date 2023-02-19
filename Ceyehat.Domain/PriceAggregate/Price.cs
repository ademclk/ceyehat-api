using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.PriceAggregate.Entities;
using Ceyehat.Domain.PriceAggregate.ValueObjects;

namespace Ceyehat.Domain.PriceAggregate;

public sealed class Price : AggregateRoot<PriceId>
{
    public decimal Amount { get; private set; }
    public Currency Currency { get; private set; }

    public FlightPricing FlightPricing { get; private set; }
    
    public DateTime CreatedAt { get; private set; }
    
    public DateTime UpdatedAt { get; private set; }

    private Price(
        PriceId id,
        decimal amount,
        Currency currency,
        FlightPricing flightPricing,
        DateTime createdAt,
        DateTime updatedAt) : base(id)
    {
        Id = id;
        Amount = amount;
        Currency = currency;
        FlightPricing = flightPricing;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Price Create(
        decimal amount,
        Currency currency,
        FlightPricing flightPricing)
    {
        return new(
            PriceId.CreateUnique(),
            amount,
            currency,
            flightPricing,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Price()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}