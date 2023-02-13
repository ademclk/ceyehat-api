using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Ceyehat.Domain.Common.Models;

namespace Ceyehat.Domain.AirlineAggregate.Entities;

public sealed class AirlineAddress : Entity<AirlineAddressId>
{
    public CityId CityId { get; private set; }

    private AirlineAddress(
        AirlineAddressId airlineAddressId,
        CityId cityId) : base(airlineAddressId)
    {
        CityId = cityId;
    }

    public static AirlineAddress Create(
        CityId cityId)
    {
        return new(
            AirlineAddressId.CreateUnique(),
            cityId);
    }
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    private AirlineAddress()
    {
    }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
}