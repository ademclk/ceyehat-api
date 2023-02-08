using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate.Entities;

public sealed class FlightTicket : Entity<FlightTicketId>
{
    public FlightId FlightId { get; }
    public SeatId SeatId { get; }
    public BoardingPass BoardingPass { get; }

    private FlightTicket(
        FlightTicketId flightTicketId,
        FlightId flightId,
        SeatId seatId,
        BoardingPass boardingPass)
        : base(flightTicketId)
    {
        FlightId = flightId;
        SeatId = seatId;
        BoardingPass = boardingPass;
    }

    public static FlightTicket Create(
        FlightId flightId,
        SeatId seatId,
        BoardingPass boardingPass)
    {
        return new(
            FlightTicketId.CreateUnique(),
            flightId,
            seatId,
            boardingPass);
    }
}