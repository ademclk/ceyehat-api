using Ceyehat.Domain.CustomerAggregate;
using Ceyehat.Domain.CustomerAggregate.Entities;

namespace Ceyehat.Application.Common.Interfaces.Persistence;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerByIdAsync(string id);
    Task<Customer?> GetCustomerByEmailAsync(string email);
    Task AddCustomerAsync(Customer customer);
    Task UpdateCustomerAsync(Customer customer);
}