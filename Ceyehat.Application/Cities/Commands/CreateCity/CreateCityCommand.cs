using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Cities.Commands.CreateCity;

public record CreateCityCommand(
    string? Name,
    string? CountryId,
    List<DistrictCommand> Districts) : IRequest<ErrorOr<City>>;

public record DistrictCommand(
    string? Name,
    string? CityId,
    List<NeighborhoodCommand> Neighborhoods);

public record NeighborhoodCommand(
    string? Name,
    string? CityId,
    string? AirlineId,
    string? AirportId);