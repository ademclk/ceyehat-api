using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.CustomerAggregate.Entities;

public sealed class Booking : Entity<BookingId>
{
    public SeatId? SeatId { get; }
    public FlightId? FlightId { get; }
    
    public Booking(
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
}