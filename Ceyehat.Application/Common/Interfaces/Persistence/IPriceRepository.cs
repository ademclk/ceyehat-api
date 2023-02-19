using Ceyehat.Domain.PriceAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface IPriceRepository
{
    Task AddPriceAsync(Price price);
}