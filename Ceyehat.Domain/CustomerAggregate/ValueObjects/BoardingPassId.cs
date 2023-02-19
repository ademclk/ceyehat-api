using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.CustomerAggregate.ValueObjects;

public sealed class BoardingPassId : ValueObject
{
    public Guid Value { get; private set; }

    private BoardingPassId(Guid value)
    {
        Value = value;
    }

    public static BoardingPassId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static BoardingPassId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected BoardingPassId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}