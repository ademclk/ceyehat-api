using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.UserAggregate.ValueObjects;

public sealed class RelationshipId : ValueObject
{
    public Guid Value { get; }

    private RelationshipId(Guid value)
    {
        Value = value;
    }

    public static RelationshipId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}