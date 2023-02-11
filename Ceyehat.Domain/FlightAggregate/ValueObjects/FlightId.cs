using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.FlightAggregate.ValueObjects;

public sealed class FlightId : ValueObject
{
    public Guid Value { get; private set; }

    private FlightId(Guid value)
    {
        Value = value;
    }

    public static FlightId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static FlightId Create(Guid value)
    {
        return new(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private FlightId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}