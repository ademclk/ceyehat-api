using Ceyehat.Domain.CustomerAggregate;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(string id);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
}