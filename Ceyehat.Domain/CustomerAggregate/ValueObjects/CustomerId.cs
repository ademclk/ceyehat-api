using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CustomerAggregate.ValueObjects;

public sealed class CustomerId : ValueObject
{
    public Guid Value { get; }

    private CustomerId(Guid value)
    {
        Value = value;
    }

    public static CustomerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CustomerId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}