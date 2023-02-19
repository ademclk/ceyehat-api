using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PriceAggregate.ValueObjects;

public sealed class PriceId : ValueObject
{
    public Guid Value { get; private set; }

    private PriceId(Guid value)
    {
        Value = value;
    }

    public static PriceId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static PriceId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected PriceId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}