using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.Airline.ValueObjects;

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

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}