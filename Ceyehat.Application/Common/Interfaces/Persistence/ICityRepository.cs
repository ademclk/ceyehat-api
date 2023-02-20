using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICityRepository
{
    Task<City?> GetCityByIdAsync(CityId cityId);
    Task AddCityAsync(City city);
}