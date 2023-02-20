using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.Enums;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Countries.Commands.CreateCountry;

public record CreateCountryCommand(
    string UnLocode,
    string Name,
    string? Iso2,
    string? Iso3,
    Currency Currency) : IRequest<ErrorOr<Country>>;