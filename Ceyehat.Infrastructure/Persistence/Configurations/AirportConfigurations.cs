using Ceyehat.Domain.AirportAggregate;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.CityAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class AirportConfigurations : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        ConfigureAirportsTable(builder);
        ConfigureAirportDepartureFlightIdsTable(builder);
        ConfigureAirportArrivalFlightIdsTable(builder);
    }

    private void ConfigureAirportArrivalFlightIdsTable(EntityTypeBuilder<Airport> builder)
    {
        builder.OwnsMany(
            a => a.ArrivalFlights,
            afb =>
            {
                afb.ToTable("AirportArrivalFlightIds");

                afb.WithOwner().HasForeignKey("AirportId");

                afb.HasKey("Id");

                afb.Property(f => f.Value)
                    .HasColumnName("FlightId")
                    .ValueGeneratedNever();
            });
        builder.Metadata.FindNavigation(nameof(Airport.ArrivalFlights))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAirportDepartureFlightIdsTable(EntityTypeBuilder<Airport> builder)
    {
        builder.OwnsMany(
            a => a.DepartureFlights,
            dfb =>
            {

                dfb.ToTable("AirportDepartureFlightIds");

                dfb.WithOwner().HasForeignKey("AirportId");

                dfb.HasKey("Id");

                dfb.Property(f => f.Value)
                    .HasColumnName("FlightId")
                    .ValueGeneratedNever();
            });
        builder.Metadata.FindNavigation(nameof(Airport.DepartureFlights))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureAirportsTable(EntityTypeBuilder<Airport> builder)
    {

        builder.ToTable("Airports");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AirportId.Create(value));

        builder.Property(a => a.Name)
            .HasMaxLength(100);

        builder.Property(a => a.IataCode)
            .HasMaxLength(16);

        builder.Property(a => a.IcaoCode)
            .HasMaxLength(16);

        builder.Property(a => a.Latitude)
            .HasColumnType("float");

        builder.Property(a => a.Longitude)
            .HasColumnType("float");

        builder.Property(a => a.TimeZone)
            .HasMaxLength(16);

        builder.Property(a => a.CityId)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => CityId.Create(value));
    }
}