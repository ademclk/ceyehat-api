using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.ValueObjects;

public sealed class DistrictId : ValueObject
{
    public Guid Value { get; }
    
    private DistrictId(Guid value)
    {
        Value = value;
    }
    
    public static DistrictId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}