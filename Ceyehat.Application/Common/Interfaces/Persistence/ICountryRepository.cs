using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.CountryAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICountryRepository
{
    Task<Country?> GetCountryByIdAsync(CountryId countryId);
    Task AddCountryAsync(Country country);
}