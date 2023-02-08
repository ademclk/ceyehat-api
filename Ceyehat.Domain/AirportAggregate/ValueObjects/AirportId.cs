using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirportAggregate.ValueObjects;

public sealed class AirportId : ValueObject
{
    public Guid Value { get; }

    private AirportId(Guid value)
    {
        Value = value;
    }

    public static AirportId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}