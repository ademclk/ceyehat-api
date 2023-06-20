using Ceyehat.Domain.CityAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Cities.Queries.GetCityById;

public abstract record GetCityByIdQuery(
    string Id
) : IRequest<ErrorOr<City>>;