using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.SeatAggregate.ValueObjects;

public sealed class SeatId : ValueObject
{
    public Guid Value { get; private set; }

    private SeatId(Guid value)
    {
        Value = value;
    }

    public static SeatId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static SeatId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private SeatId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}