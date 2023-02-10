using System.Configuration;
using Ceyehat.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Ceyehat.Infrastructure.Persistence;

public partial class CeyehatDbContext : DbContext
{
    public CeyehatDbContext(DbContextOptions<CeyehatDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CeyehatDbContext).Assembly);
            
        base.OnModelCreating(modelBuilder);
    }
}