using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate.Entities;

public sealed class AirlineAddress : Entity<AirlineAddressId>
{
    public CityId CityId { get; }

    private AirlineAddress(
        AirlineAddressId airlineAddressId,
        CityId cityId) : base(airlineAddressId)
    {
        CityId = cityId;
    }

    public static AirlineAddress Create(
        AirlineAddressId airlineAddressId,
        CityId cityId)
    {
        return new(
            AirlineAddressId.CreateUnique(),
            cityId);
    }
}