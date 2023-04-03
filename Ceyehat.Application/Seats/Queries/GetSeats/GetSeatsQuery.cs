using Ceyehat.Application.Common.DTOs;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Seats.Queries.GetSeats;

public record GetSeatsQuery(
    string? FlightNumber,
    string? AircraftName
    ) : IRequest<ErrorOr<List<SeatDto>>>;
