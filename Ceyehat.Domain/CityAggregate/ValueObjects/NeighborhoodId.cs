using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.ValueObjects;

public sealed class NeighborhoodId : ValueObject
{
    public Guid Value { get; }

    private NeighborhoodId(Guid value)
    {
        Value = value;
    }

    public static NeighborhoodId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}