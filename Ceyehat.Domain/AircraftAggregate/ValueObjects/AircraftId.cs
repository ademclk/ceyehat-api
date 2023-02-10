using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AircraftAggregate.ValueObjects;

public sealed class AircraftId : ValueObject
{
    public Guid Value { get; private set; }

    private AircraftId(Guid value)
    {
        Value = value;
    }

    public static AircraftId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AircraftId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private AircraftId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}