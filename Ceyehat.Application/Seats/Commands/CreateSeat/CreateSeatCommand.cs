using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.SeatAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Seats.Commands.CreateSeat;

public record CreateSeatCommand(
    string? SeatNumber,
    SeatClass SeatClass,
    SeatStatus SeatStatus,
    string? AircraftId) : IRequest<ErrorOr<Seat>>;