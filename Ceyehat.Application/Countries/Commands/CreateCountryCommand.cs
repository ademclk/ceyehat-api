using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.Enums;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Countries.Commands;

public record CreateCountryCommand(
    string UnLocode,
    string Name,
    string? IsoCode,
    string? Iso3Code,
    Currency Currency) : IRequest<ErrorOr<Country>>;