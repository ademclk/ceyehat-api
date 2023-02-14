using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly CeyehatDbContext _dbContext;

    public CustomerRepository(CeyehatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddCustomerAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(customer);
        await _dbContext.SaveChangesAsync();
    }
}