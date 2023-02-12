using Ceyehat.Domain.CountryAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICountryRepository
{
    Task AddCountryAsync(Country country);
}