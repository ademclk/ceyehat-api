using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CountryAggregate;
using MediatR;
using ErrorOr;

namespace Ceyehat.Application.Countries.Commands;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, ErrorOr<Country>>
{
    private readonly ICountryRepository _countryRepository;

    public CreateCountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ErrorOr<Country>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = Country.Create(
            request.UnLocode,
            request.Name,
            request.IsoCode,
            request.Iso3Code,
            request.Currency);

        await _countryRepository.AddCountryAsync(country);

        return country;
    }
}