using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.Seat.ValueObjects;

public sealed class SeatId : ValueObject
{
    public Guid Value { get; }

    private SeatId(Guid value)
    {
        Value = value;
    }
    
    public static SeatId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}