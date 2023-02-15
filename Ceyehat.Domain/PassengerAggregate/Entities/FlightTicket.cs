using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate.Entities;

public sealed class FlightTicket : Entity<FlightTicketId>
{
    public BookingId BookingId { get; private set; }

    private FlightTicket(
        FlightTicketId flightTicketId,
        BookingId bookingId)
        : base(flightTicketId)
    {
        BookingId = bookingId;
    }

    public static FlightTicket Create(
        BookingId bookingId)
    {
        return new(
            FlightTicketId.CreateUnique(),
            bookingId);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private FlightTicket()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}