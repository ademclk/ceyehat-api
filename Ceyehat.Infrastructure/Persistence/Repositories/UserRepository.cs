using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.UserAggregate;
using Ceyehat.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Ceyehat.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly CeyehatDbContext _dbContext;

    public UserRepository(CeyehatDbContext context)
    {
        _dbContext = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u!.Email == email);
    }

    public async Task AddUserAsync(User? user)
    {
        await _dbContext.Users.AddAsync(user!);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<UserId?> GetUserIdByEmailAsync(string email)
    {
        var userId = await _dbContext.Users.FirstOrDefaultAsync(u => u!.Email == email);
        if (userId == null)
        {
            throw new NpgsqlException("User not found");
        }

        return userId?.Id;
    }
}