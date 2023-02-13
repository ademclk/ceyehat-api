using System.Configuration;
using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AirlineAggregate;
using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.CountryAggregate;
using Ceyehat.Domain.FlightAggregate;
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
    public DbSet<Aircraft> Aircrafts { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Airline> Airlines { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CeyehatDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}