using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CustomerAggregate.ValueObjects;

public sealed class BookingId : ValueObject
{
    public Guid Value { get; }

    private BookingId(Guid value)
    {
        Value = value;
    }

    public static BookingId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}