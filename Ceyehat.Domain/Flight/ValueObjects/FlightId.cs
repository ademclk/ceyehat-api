using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.Flight.ValueObjects;

public sealed class FlightId : ValueObject
{
    public Guid Value { get; }
    
    private FlightId(Guid value)
    {
        Value = value;
    }
    
    public static FlightId CreateUnique()
    {
        return new FlightId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}