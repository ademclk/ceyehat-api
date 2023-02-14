using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.ValueObjects;

public sealed class DistrictId : ValueObject
{
    public Guid Value { get; private set; }

    private DistrictId(Guid value)
    {
        Value = value;
    }

    public static DistrictId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static DistrictId Create(Guid value)
    {
        return new(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private DistrictId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}