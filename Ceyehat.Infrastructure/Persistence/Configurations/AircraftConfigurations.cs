using Ceyehat.Domain.AircraftAggregate;
using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CountryAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class AircraftConfigurations : IEntityTypeConfiguration<Aircraft>
{
    public void Configure(EntityTypeBuilder<Aircraft> builder)
    {
        ConfigureAircraftsTable(builder);
        ConfigureAircraftFlightIdsTable(builder);
        ConfigureAircraftSeatIdsTable(builder);
    }

    private void ConfigureAircraftSeatIdsTable(EntityTypeBuilder<Aircraft> builder)
    {
        builder.OwnsMany(a => a.SeatIds, sib =>
        {
            sib.ToTable("AircraftSeatIds");

            sib.WithOwner().HasForeignKey("AircraftId");

            sib.HasKey("Id");

            sib.Property(s => s.Value)
                .HasColumnName("SeatId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Aircraft.SeatIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAircraftFlightIdsTable(EntityTypeBuilder<Aircraft> builder)
    {
        builder.OwnsMany(a => a.FlightIds, fib =>
        {
            fib.ToTable("AircraftFlightIds");

            fib.WithOwner().HasForeignKey("AircraftId");

            fib.HasKey("Id");

            fib.Property(f => f.Value)
                .HasColumnName("FlightId")
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Aircraft.FlightIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAircraftsTable(EntityTypeBuilder<Aircraft> builder)
    {
        builder.ToTable("Aircrafts");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AircraftId.Create(value));

        builder.Property(a => a.RegistrationNumber)
            .HasMaxLength(32);

        builder.Property(a => a.Icao24Code)
            .HasMaxLength(32);

        builder.Property(a => a.Model)
            .HasMaxLength(64);

        builder.Property(a => a.ManufacturerSerialNumber)
            .HasMaxLength(32);

        builder.Property(a => a.FaaRegistration)
            .HasMaxLength(32);

        builder.Property(a => a.CountryId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CountryId.Create(value));
        
        builder.Property(a => a.AirlineId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AirlineId.Create(value));
    }
}