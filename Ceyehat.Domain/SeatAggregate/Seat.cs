using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.SeatAggregate;

public sealed class Seat : AggregateRoot<SeatId>
{
    public string? SeatNumber { get; private set; }
    public SeatClass SeatClass { get; private set; }
    public SeatStatus SeatStatus { get; private set; }

    public AircraftId AircraftId { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private Seat(
        SeatId seatId,
        string? seatNumber,
        SeatClass seatClass,
        SeatStatus seatStatus,
        AircraftId aircraftId,
        DateTime createdAt,
        DateTime updatedAt) : base(seatId)
    {
        SeatNumber = seatNumber;
        SeatClass = seatClass;
        SeatStatus = seatStatus;
        AircraftId = aircraftId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Seat Create(
        string? seatNumber,
        SeatClass seatClass,
        SeatStatus seatStatus,
        AircraftId aircraftId)
    {
        return new(
            SeatId.CreateUnique(),
            seatNumber,
            seatClass,
            seatStatus,
            aircraftId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private Seat()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable. 
    
}