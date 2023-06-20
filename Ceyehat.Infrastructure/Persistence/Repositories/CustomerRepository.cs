using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

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

    public async Task UpdateCustomerAsync(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(string id)
    {
        return await _dbContext.Customers.FindAsync(id);
    }

    public async Task<Customer?> GetCustomerByEmailAsync(string email)
    {
        return await _dbContext.Customers.FirstOrDefaultAsync(x => x.Email == email);
    }
}