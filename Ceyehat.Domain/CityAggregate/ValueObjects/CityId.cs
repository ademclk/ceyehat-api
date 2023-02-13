using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.ValueObjects;

public sealed class CityId : ValueObject
{
    public Guid Value { get; }

    private CityId(Guid value)
    {
        Value = value;
    }

    public static CityId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static CityId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}