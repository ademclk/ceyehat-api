using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CityAggregate;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Ceyehat.Application.Cities.Queries.GetCityById;

public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, ErrorOr<City>>
{
    private readonly ICityRepository _cityRepository;

    public GetCityByIdQueryHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<ErrorOr<City>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var cityId = CityId.Create(Guid.Parse(request.Id));
        var city = await _cityRepository.GetCityByIdAsync(cityId);

        if (city! == null!)
        {
            return Errors.City.NotFound;
        }

        return city;
    }
}