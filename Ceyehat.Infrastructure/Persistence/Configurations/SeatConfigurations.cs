using Ceyehat.Domain.AircraftAggregate.ValueObjects;
using Ceyehat.Domain.Enums;
using Ceyehat.Domain.FlightAggregate.ValueObjects;
using Ceyehat.Domain.SeatAggregate;
using Ceyehat.Domain.SeatAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ceyehat.Infrastructure.Persistence.Configurations;

public class SeatConfigurations : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        ConfigureSeatsTable(builder);
    }

    private void ConfigureSeatsTable(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seats");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .ValueGeneratedNever()
            .HasConversion(
                s => s.Value,
                value => SeatId.Create(value));

        builder.Property(s => s.SeatNumber)
            .HasMaxLength(4);

        builder.Property(s => s.SeatClass)
            .HasConversion(
                type => (int)type,
                intValue => (SeatClass)intValue);

        builder.Property(s => s.SeatStatus)
            .HasConversion(
                type => (int)type,
                intValue => (SeatStatus)intValue);

        builder.Property(s => s.AircraftId)
            .ValueGeneratedNever()
            .HasConversion(
                s => s.Value,
                value => AircraftId.Create(value));
        
        builder.Property(s => s.FlightId)
            .ValueGeneratedNever()
            .HasConversion(
                s => s.Value,
                value => FlightId.Create(value));
    }
}