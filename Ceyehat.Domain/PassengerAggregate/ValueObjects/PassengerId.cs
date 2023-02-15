using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PassengerAggregate.ValueObjects;

public sealed class PassengerId : ValueObject
{
    public Guid Value { get; private set; }

    private PassengerId(Guid value)
    {
        Value = value;
    }

    public static PassengerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static PassengerId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private PassengerId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}