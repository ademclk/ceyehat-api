using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PassengerAggregate.ValueObjects;

public sealed class FlightTicketId : ValueObject
{
    public Guid Value { get; }

    public FlightTicketId(Guid value)
    {
        Value = value;
    }

    public static FlightTicketId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}