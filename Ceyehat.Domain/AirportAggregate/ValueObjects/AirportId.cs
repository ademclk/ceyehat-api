using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirportAggregate.ValueObjects;

public sealed class AirportId : ValueObject
{
    public Guid Value { get; private set; }

    private AirportId(Guid value)
    {
        Value = value;
    }

    public static AirportId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AirportId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private AirportId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}
