using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PassengerAggregate.ValueObjects;

public sealed class BoardingPassId : ValueObject
{
    public Guid Value { get; private set; }

    public BoardingPassId(Guid value)
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
    private BoardingPassId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}