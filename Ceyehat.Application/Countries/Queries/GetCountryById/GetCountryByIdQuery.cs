using Ceyehat.Domain.CountryAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Countries.Queries.GetCountryById;

public record GetCountryByIdQuery(
    string Id
    ) : IRequest<ErrorOr<Country>>;