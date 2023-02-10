using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.UserAggregate.ValueObjects;

public sealed class RelationshipId : ValueObject
{
    public Guid Value { get; private set; }

    private RelationshipId(Guid value)
    {
        Value = value;
    }

    public static RelationshipId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static RelationshipId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private RelationshipId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}