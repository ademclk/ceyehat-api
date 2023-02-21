using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.Enums;

namespace Ceyehat.Contracts.Seats;

public record SeatResponse(
    string? Id,
    string? SeatNumber,
    string SeatClass,
    string SeatStatus,
    string? AircraftId,
    DateTime CreatedAt,
    DateTime UpdatedAt);