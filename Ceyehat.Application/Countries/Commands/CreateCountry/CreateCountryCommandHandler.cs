using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CountryAggregate;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Countries.Commands.CreateCountry;

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
            request.Iso2,
            request.Iso3,
            request.Currency);

        await _countryRepository.AddCountryAsync(country);

        return country;
    }
}