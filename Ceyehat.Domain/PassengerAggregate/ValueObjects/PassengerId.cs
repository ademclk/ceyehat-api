using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PassengerAggregate.ValueObjects;

public sealed class PassengerId : ValueObject
{
    public Guid Value { get; }
    
    private PassengerId(Guid value)
    {
        Value = value;
    }
    
    public static PassengerId CreateUnique()
    {
        return new(Guid.NewGuid());
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}