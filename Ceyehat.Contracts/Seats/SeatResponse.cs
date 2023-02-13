using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Seats;

public record SeatResponse(
    string Id,
    string? SeatNumber,
    SeatClass SeatClass,
    SeatStatus SeatStatus,
    string AircraftId,
    DateTime CreatedAt,
    DateTime UpdatedAt);