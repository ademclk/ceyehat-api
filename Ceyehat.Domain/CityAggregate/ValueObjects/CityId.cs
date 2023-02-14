using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CityAggregate.ValueObjects;

public sealed class CityId : ValueObject
{
    public Guid Value { get; private set; }

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
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private CityId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}