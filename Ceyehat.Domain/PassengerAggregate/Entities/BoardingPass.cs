using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.PassengerAggregate.ValueObjects;

namespace Ceyehat.Domain.PassengerAggregate.Entities;

public sealed class BoardingPass : Entity<BoardingPassId>
{
    public FlightTicketId FlightTicketId { get; private set; }
    public string? Gate { get; private set; }
    public DateTime BoardingTime { get; private set; }

    private BoardingPass(
        BoardingPassId boardingPassId,
        FlightTicketId flightTicketId,
        string? gate,
        DateTime boardingTime)
        : base(boardingPassId)
    {
        FlightTicketId = flightTicketId;
        Gate = gate;
        BoardingTime = boardingTime;
    }

    public static BoardingPass Create(
        FlightTicketId flightTicketId,
        string? gate,
        DateTime boardingTime)
    {
        return new(
            BoardingPassId.CreateUnique(),
            flightTicketId,
            gate,
            boardingTime);
    }
    
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private BoardingPass()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}