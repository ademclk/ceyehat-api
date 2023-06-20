using Ceyehat.Domain.AirportAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Airports.Queries.GetAirports;

public record GetAirportsQuery : IRequest<ErrorOr<List<Airport>>>;