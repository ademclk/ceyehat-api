using Ceyehat.Domain.AirlineAggregate;
using Ceyehat.Domain.AirlineAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class AirlineConfigurations : IEntityTypeConfiguration<Airline>
{
    public void Configure(EntityTypeBuilder<Airline> builder)
    {
        ConfigureAirlinesTable(builder);
        ConfigureAirlineAddressTable(builder);
        ConfigureAirlineAircraftIdsTable(builder);
    }

    private void ConfigureAirlineAircraftIdsTable(EntityTypeBuilder<Airline> builder)
    {
        builder.OwnsMany(
            a => a.AircraftIds,
            ab =>
            {
                ab.ToTable("AirlineAircraftIds");

                ab.WithOwner().HasForeignKey("AirlineId");

                ab.HasKey("Id");

                ab.Property(a => a.Value)
                    .HasColumnName("AircraftId")
                    .ValueGeneratedNever();
            });

        builder.Metadata.FindNavigation(nameof(Airline.AircraftIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAirlineAddressTable(EntityTypeBuilder<Airline> builder)
    {
        builder.OwnsOne(
            a => a.AirlineAddress,
            ab =>
            {
                ab.ToTable("AirlineAddresses");

                ab.WithOwner().HasForeignKey("AirlineId");

                ab.HasKey("Id", "AirlineId");

                ab.Property(a => a.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => AirlineAddressId.Create(value));

                ab.Property(a => a.CityId)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => CityId.Create(value));
            });

        builder.Metadata.FindNavigation(nameof(Airline.AirlineAddress))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAirlinesTable(EntityTypeBuilder<Airline> builder)
    {
        builder.ToTable("Airlines");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                a => a.Value,
                value => AirlineId.Create(value));

        builder.Property(a => a.Name)
            .HasMaxLength(256);

        builder.Property(a => a.IataCode)
            .HasMaxLength(16);

        builder.Property(a => a.IcaoCode)
            .HasMaxLength(16);

        builder.Property(a => a.Callsign)
            .HasMaxLength(64);

        builder.Property(a => a.Code)
            .HasMaxLength(32);

        builder.Property(a => a.Website)
            .HasMaxLength(128);
    }
}