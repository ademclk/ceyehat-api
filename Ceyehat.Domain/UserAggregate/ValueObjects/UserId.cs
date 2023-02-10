using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.UserAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; private set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public static UserId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private UserId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}