using Ceyehat.Domain.CityAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Cities.Commands.CreateCity;

public abstract record CreateCityCommand(
    string? Name,
    string? CountryId,
    List<DistrictCommand> Districts) : IRequest<ErrorOr<City>>;

public abstract record DistrictCommand(
    string? Name,
    string? CityId,
    List<NeighborhoodCommand> Neighborhoods);

public abstract record NeighborhoodCommand(
    string? Name,
    string? CityId,
    string? AirlineId,
    string? AirportId);