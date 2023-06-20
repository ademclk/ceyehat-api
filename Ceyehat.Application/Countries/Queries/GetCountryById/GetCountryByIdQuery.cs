using Ceyehat.Domain.CountryAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Countries.Queries.GetCountryById;

public abstract record GetCountryByIdQuery(
    string Id
    ) : IRequest<ErrorOr<Country>>;