using System.Configuration;
using Ceyehat.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Ceyehat.Infrastructure;

public partial class CeyehatDbContext : DbContext
{
    public CeyehatDbContext()
    {
    }

    public CeyehatDbContext(DbContextOptions<CeyehatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasColumnName("user_id")
                .HasDefaultValueSql("uuid_generate_v4()");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(64);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasMaxLength(255);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(128);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasColumnName("last_name")
                .HasMaxLength(128);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}