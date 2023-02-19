using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;

namespace Ceyehat.Domain.FlightAggregate.Entities;

public class Price : Entity<PriceId>
{
    public float Value { get; private set; }
    public Currency Currency { get; private set; }
    public SeatClass SeatClass { get; private set; }
    public FlightId? FlightId { get; private set; }

    private Price(
        PriceId priceId,
        float value,
        Currency currency,
        SeatClass seatClass,
        FlightId flightId) : base(priceId)
    {
        Value = value;
        Currency = currency;
        SeatClass = seatClass;
        FlightId = flightId;
    }

    public static Price Create(
        float value,
        Currency currency,
        SeatClass seatClass,
        FlightId flightId)
    {
        return new(
            PriceId.CreateUnique(),
            value,
            currency,
            seatClass,
            flightId);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected Price()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.

}