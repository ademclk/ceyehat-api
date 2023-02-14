using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CustomerAggregate.ValueObjects;

public sealed class BookingId : ValueObject
{
    public Guid Value { get; private set; }

    private BookingId(Guid value)
    {
        Value = value;
    }

    public static BookingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BookingId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected BookingId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}