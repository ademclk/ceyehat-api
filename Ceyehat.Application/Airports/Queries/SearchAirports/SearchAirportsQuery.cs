using Ceyehat.Application.Common.DTOs;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Airports.Queries.SearchAirports;

public record SearchAirportsQuery(
    string? SearchTerm
    ) : IRequest<ErrorOr<List<AirportDto>>>;