using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate.ValueObjects;

public sealed class AirlineId : ValueObject
{
    public Guid Value { get; private set; }

    private AirlineId(Guid value)
    {
        Value = value;
    }

    public static AirlineId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AirlineId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private AirlineId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}