using Ceyehat.Application.Common.Interfaces.Persistence;
using Ceyehat.Domain.User;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Ceyehat.Infrastructure.Persistence;

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
}