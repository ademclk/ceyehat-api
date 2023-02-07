using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate.ValueObjects;

public sealed class AirlineAddressId : ValueObject
{
    public Guid Value { get; }
    
    private AirlineAddressId(Guid value)
    {
        Value = value;
    }
    
    public static AirlineAddressId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}