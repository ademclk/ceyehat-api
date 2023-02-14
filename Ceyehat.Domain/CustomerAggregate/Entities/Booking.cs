using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.CustomerAggregate.Entities;

public sealed class Booking : Entity<BookingId>
{
    public SeatId? SeatId { get; private set; }
    public FlightId? FlightId { get; private set; }

    private Booking(
        BookingId bookingId,
        SeatId seatId,
        FlightId flightId) : base(bookingId)
    {
        SeatId = seatId;
        FlightId = flightId;
    }

    public static Booking Create(
        SeatId seatId,
        FlightId flightId)
    {
        return new(
            BookingId.CreateUnique(),
            seatId,
            flightId);
    }

#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected Booking()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}