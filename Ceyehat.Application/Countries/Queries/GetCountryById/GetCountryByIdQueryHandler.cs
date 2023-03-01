using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.Common.Errors;
using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Countries.Queries.GetCountryById;

public class GetCountryByIdQueryHandler : IRequestHandler<GetCountryByIdQuery, ErrorOr<Country>>
{
    private readonly ICountryRepository _countryRepository;

    public GetCountryByIdQueryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<ErrorOr<Country>> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
    {
        var countryId = CountryId.Create(Guid.Parse(request.Id));

        var country = await _countryRepository.GetCountryByIdAsync(countryId);

        if (country! == null!)
        {
            return Errors.Country.NotFound;
        }

        return country;

    }
}