using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.CustomerAggregate.ValueObjects;

namespace Ceyehat.Domain.CustomerAggregate.Entities;

public class FlightTicket : Entity<FlightTicketId>
{
    public BoardingPassId? BoardingPassId { get; private set; }
    public BookingId BookingId { get; private set; }

    private FlightTicket(
        FlightTicketId flightTicketId,
        BoardingPassId? boardingPassId,
        BookingId bookingId) : base(flightTicketId)
    {
        BoardingPassId = boardingPassId;
        BookingId = bookingId;
    }

    public static FlightTicket Create(
        BoardingPassId? boardingPassId,
        BookingId bookingId)
    {
        return new(
            FlightTicketId.CreateUnique(),
            boardingPassId,
            bookingId);
    }

    public void AddBoardingPass(BoardingPassId boardingPassId)
    {
        if (BoardingPassId! != null!)
        {
            throw new InvalidOperationException("Boarding pass has already been added to this flight ticket.");
        }

        BoardingPassId = boardingPassId;
    }


#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    protected FlightTicket()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}