using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.Aircraft.ValueObjects;

public sealed class AircraftId : ValueObject
{
    public Guid Value { get; }

    private AircraftId(Guid value)
    {
        Value = value;
    }

    public static AircraftId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}