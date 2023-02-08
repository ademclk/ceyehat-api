using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.SeatAggregate.ValueObjects;

namespace Ceyehat.Domain.SeatAggregate;

public sealed class Seat : AggregateRoot<SeatId>
{
    public string? SeatNumber { get; }
    public SeatClass SeatClass { get; }
    public SeatStatus SeatStatus { get; }

    public AircraftId AircraftId { get; }
    
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

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
}