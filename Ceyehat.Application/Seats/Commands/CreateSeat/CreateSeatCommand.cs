using Ceyehat.Domain.Enums;
using Ceyehat.Domain.SeatAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Seats.Commands.CreateSeat;

public abstract record CreateSeatCommand(
    string? SeatNumber,
    SeatClass SeatClass,
    SeatStatus SeatStatus,
    string? AircraftId,
    string? FlightId) : IRequest<ErrorOr<Seat>>;