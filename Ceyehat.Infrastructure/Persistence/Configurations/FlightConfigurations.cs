using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.AirportAggregate.ValueObjects;
using Ceyehat.Domain.FlightAggregate;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class FlightConfigurations : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        ConfigureFlightsTable(builder);
    }

    private void ConfigureFlightsTable(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("Flights");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever()
            .HasConversion(
                f => f.Value,
                value => FlightId.Create(value));

        builder.Property(f => f.FlightNumber)
            .HasMaxLength(32);

        builder.Property(f => f.ScheduledDeparture)
            .HasMaxLength(256);

        builder.Property(f => f.ScheduledArrival)
            .HasMaxLength(256);

        builder.Property(f => f.Status)
            .HasMaxLength(32);

        builder.Property(f => f.Type)
            .HasMaxLength(32);

        builder.Property(f => f.ActualDeparture)
            .HasMaxLength(256);

        builder.Property(f => f.ActualArrival)
            .HasMaxLength(256);

        builder.Property(f => f.AircraftId)
            .ValueGeneratedNever()
            .HasConversion(
                f => f.Value,
                value => AircraftId.Create(value));

        builder.Property(f => f.DepartureAirportId)
            .ValueGeneratedNever()
            .HasConversion(
                f => f.Value,
                value => AirportId.Create(value));

        builder.Property(f => f.ArrivalAirportId)
            .ValueGeneratedNever()
            .HasConversion(
                f => f.Value,
                value => AirportId.Create(value));
    }
}