using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PassengerAggregate.ValueObjects;

public sealed class BoardingPassId : ValueObject
{
    public Guid Value { get; }
    
    public BoardingPassId(Guid value)
    {
        Value = value;
    }
    
    public static BoardingPassId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}