using Ceyehat.Application.Common.DTOs;
using Ceyehat.Domain.AirportAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Airports.Queries.SearchAirports;

public record SearchAirportsQuery(
    string? SearchTerm
    ) : IRequest<ErrorOr<List<AirportDto>>>;