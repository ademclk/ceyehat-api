using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate.ValueObjects;

public sealed class AirlineAddressId : ValueObject
{
    public Guid Value { get; private set; }

    private AirlineAddressId(Guid value)
    {
        Value = value;
    }

    public static AirlineAddressId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static AirlineAddressId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private AirlineAddressId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}