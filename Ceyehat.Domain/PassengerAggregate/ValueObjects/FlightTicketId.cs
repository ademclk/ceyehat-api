using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.PassengerAggregate.ValueObjects;

public sealed class FlightTicketId : ValueObject
{
    public Guid Value { get; private set; }

    private FlightTicketId(Guid value)
    {
        Value = value;
    }

    public static FlightTicketId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static FlightTicketId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private FlightTicketId()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}