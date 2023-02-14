using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.ValueObjects;

public sealed class NeighborhoodId : ValueObject
{
    public Guid Value { get; private set; }

    private NeighborhoodId(Guid value)
    {
        Value = value;
    }

    public static NeighborhoodId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static NeighborhoodId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private NeighborhoodId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}