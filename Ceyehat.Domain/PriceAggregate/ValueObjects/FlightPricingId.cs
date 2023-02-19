using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PriceAggregate.ValueObjects;

public sealed class FlightPricingId : ValueObject
{
    public Guid Value { get; private set; }

    private FlightPricingId(Guid value)
    {
        Value = value;
    }

    public static FlightPricingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static FlightPricingId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}