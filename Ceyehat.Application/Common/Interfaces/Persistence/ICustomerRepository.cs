using Ceyehat.Domain.CustomerAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task AddCustomerAsync(Customer customer);
}