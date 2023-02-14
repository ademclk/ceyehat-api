using Ceyehat.Domain.CityAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICityRepository
{
    Task AddCityAsync(City city);
}