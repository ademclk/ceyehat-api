using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate.ValueObjects;

public sealed class AirlineId : ValueObject
{
    public Guid Value { get; }

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
}